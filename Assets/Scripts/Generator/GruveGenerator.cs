using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cell
{
    public Cell(int xCoordinate, int yCoordinate, int zCoordinate) { coordinates = new int[3] { xCoordinate, yCoordinate, zCoordinate }; }

    public int[] coordinates = new int[3]; // 0 - x (c: left/right), 1 - z (c: forward/backward), 2 - y (c: up/down)
    public bool[] neighbour = new bool[4]; // 0 - up, 1 - right, 2 - down, 3 - left
    public int roomType = 0; // 0 - normal, 1 - elevator, 2 - access
    public bool elevator = false;
    public bool coal = false;
}

public class GruveGenerator : MonoBehaviour
{
    [Header("Room Prefabs")]
    public List<GameObject> rooms;

    [Header("Spawn Info")]
    private RoomBehaviour spawnRoom;
    private GruveElevator elevator;
    private CoalElevator coalElevator;

    [Header("Room Info")]
    public int maxRooms;
    public int minRooms;
    public int neighbourChance;
    public int floors;
    public Vector3 offset;
    public List<Cell> queue;

    [Header("Player")]
    public GameObject playerPreFab;
    public GameObject player;
    public Vector3 playerCoordinates;

    [Header("Game")]
    public GameManager gameManager;
    public List<GameObject> coalInventory;

    void Awake()
    {
        if (gameManager != null)
        {
            DontDestroyOnLoad(gameManager.gameObject);
        }

        queue = new List<Cell>
        {
            new Cell(0, 0, 0)
        };

        GenerateDungeon();

        CreateRooms();

        elevator = spawnRoom.GetComponentInChildren<GruveElevator>();
        coalElevator = spawnRoom.GetComponentInChildren<CoalElevator>();

        elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.topHeight, elevator.transform.position.z);

        player = Instantiate(playerPreFab);
        player.transform.position = elevator.transform.position;
        player.GetComponent<Player>().machine.Initialize(player.GetComponent<Player>().machine.walkState);

        elevator.cargo.Add(player);
        elevator.machine.TransitionTo(elevator.machine.lowerState);
    }

    private void Update()
    {
        GetCoordinates();

        if (coalElevator.atTop)
        {
            for (int i = 0; i < coalElevator.cargo.Count(); i++)
            {
                coalInventory.Add(coalElevator.cargo[i]);
                coalElevator.cargo[i].SetActive(false);
            }
            Debug.Log($"Coal Inventory now has {coalInventory.Count} {coalInventory.Count()} coal");
            
            coalElevator.cargo.Clear();
            coalElevator.machine.TransitionTo(coalElevator.machine.lowerState);
        }

        if (elevator.atTop)
        {
            for (int i = 0; i < coalInventory.Count(); i++)
            {
                CoalInfo coalTemp = coalInventory[i].GetComponent<CoalInfo>();
                gameManager.coalInventory.Add(coalTemp.value);
            }
            for (int i = 0; i < player.GetComponent<Player>().inventory.Count(); i++)
            {

            }
            GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(1);
        }
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < floors; i++)
        {
            if (i > 0)
            {
                NewFloor(queue.Last(), i);
            }

            int queuePosition = 0;
            for (int x = 0; x < queue.Count; x++)
            {
                if (queue[x].coordinates[2] == i)
                {
                    queuePosition = x;
                    break;
                }
            }

            while (FloorCount(i) < minRooms)
            {
                for (int j = queuePosition; j < queue.Count; j++)
                {
                    SetupNeighbours(queue[j], i);

                    if (FloorCount(i) >= maxRooms)
                    {
                        break;
                    }
                }

                if (FloorCount(i) >= maxRooms)
                {
                    break;
                }
            }

            Debug.Log($"There are {FloorCount(i)} rooms in floor {i}, which is more than {minRooms} and less than {maxRooms}");
        }

        //MergeCells();
    }

    void SetupNeighbours(Cell cell, int floor)
    {
        // To set up neighbours
        for (int i = 0; i < cell.neighbour.Count(); i++)
        {
            if (Random.Range(0, 100) < neighbourChance) // If the random-range is below neighbour-chance
            {
                cell.neighbour[i] = true;

                if (i == 0) // If the neighbour is above (0 - up)
                {
                    if (!CheckRoom(new int[3] { cell.coordinates[0], cell.coordinates[1] + 1, floor }))
                    {
                        queue.Add(new Cell(cell.coordinates[0], cell.coordinates[1] + 1, floor));
                        queue.Last().neighbour[2] = true;
                    }
                    else
                    {
                        FindRoom(new int[3] { cell.coordinates[0], cell.coordinates[1] + 1, floor }).neighbour[2] = true;
                    }
                }
                else if (i == 1) // If the neighbour is rightside (1 - right)
                {
                    if (!CheckRoom(new int[3] { cell.coordinates[0] + 1, cell.coordinates[1], floor }))
                    {
                        queue.Add(new Cell(cell.coordinates[0] + 1, cell.coordinates[1], floor));
                        queue.Last().neighbour[3] = true;
                    }
                    else
                    {
                        FindRoom(new int[3] { cell.coordinates[0] + 1, cell.coordinates[1], floor }).neighbour[3] = true;
                    }
                }
                else if (i == 2) // if the neighbour is below (2 - down)
                {
                    if (!CheckRoom(new int[3] { cell.coordinates[0], cell.coordinates[1] - 1, floor }))
                    {
                        queue.Add(new Cell(cell.coordinates[0], cell.coordinates[1] - 1, floor));
                        queue.Last().neighbour[0] = true;
                    }
                    else
                    {
                        FindRoom(new int[3] { cell.coordinates[0], cell.coordinates[1] - 1, floor }).neighbour[0] = true;
                    }
                }
                else if (i == 3) // if the neighbour is leftside (3 - left)
                {
                    if (!CheckRoom(new int[3] { cell.coordinates[0] - 1, cell.coordinates[1], floor }))
                    {
                        queue.Add(new Cell(cell.coordinates[0] - 1, cell.coordinates[1], floor));
                        queue.Last().neighbour[1] = true;
                    }
                    else
                    {
                        FindRoom(new int[3] { cell.coordinates[0] - 1, cell.coordinates[1], floor }).neighbour[1] = true;
                    }
                }
            }
        }
    }

    void NewFloor(Cell cell, int toFloor)
    {
        queue.Add(new Cell(cell.coordinates[0], cell.coordinates[1], toFloor));
        queue.Last().roomType = 1;
        FindRoom(new int[] { queue.Last().coordinates[0], queue.Last().coordinates[1], queue.Last().coordinates[2] - 1 }).roomType = 2;
    }

    int FloorCount(int floor)
    {
        int count = 0;
        for (int i = 0; i < queue.Count(); i++)
        {
            if (queue[i].coordinates[2] == floor)
            {
                count++;
            }
        }

        return count;
    }

    void MergeCells()
    {
        // This is literal patchwork. It doesn't "merge" the cells, rather, it gives two overlapping cells the same neighbour value
        foreach (Cell cellA in queue)
        {
            foreach (Cell cellB in queue)
            {
                // If the coordinates of two different cells are the same, merge them
                if (cellA.coordinates[0] == cellB.coordinates[0] &&
                    cellA.coordinates[1] == cellB.coordinates[1] &&
                    cellA.coordinates[2] == cellB.coordinates[2] &&
                    cellA != cellB)
                {
                    for (int i = 0; i < cellA.neighbour.Count(); i++)
                    {
                        if (cellA.neighbour[i])
                        {
                            cellB.neighbour[i] = true;
                        }
                    }
                    for (int i = 0; i < cellB.neighbour.Count(); i++)
                    {
                        if (cellB.neighbour[i])
                        {
                            cellA.neighbour[i] = true;
                        }
                    }
                }
            }
        }
    }

    void CreateRooms()
    {
        RoomBehaviour newRoom = Instantiate(rooms[1], new Vector3(queue[0].coordinates[0] * offset.x, queue[0].coordinates[2] * (offset.z * (-1)), queue[0].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
        newRoom.UpdateRoom(queue[0].neighbour);

        newRoom.name = $"Spawn Room";
        spawnRoom = newRoom;

        for (int i = 1; i < queue.Count(); i++)
        {
            if (queue[i].roomType == 0)
            {
                newRoom = Instantiate(rooms[0], new Vector3(queue[i].coordinates[0] * offset.x, queue[i].coordinates[2] * (offset.z * (-1)), queue[i].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
            }
            else if (queue[i].roomType == 1)
            {
                newRoom = Instantiate(rooms[1], new Vector3(queue[i].coordinates[0] * offset.x, queue[i].coordinates[2] * (offset.z * (-1)), queue[i].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
                newRoom.gameObject.GetComponentInChildren<GruveElevator>().transform.position = new Vector3(newRoom.gameObject.GetComponentInChildren<GruveElevator>().transform.position.x, newRoom.gameObject.GetComponentInChildren<GruveElevator>().topHeight, newRoom.gameObject.GetComponentInChildren<GruveElevator>().transform.position.z);
                newRoom.gameObject.GetComponentInChildren<GruveElevator>().atTop = true;
            }
            else if (queue[i].roomType == 2)
            {
                newRoom = Instantiate(rooms[2], new Vector3(queue[i].coordinates[0] * offset.x, queue[i].coordinates[2] * (offset.z * (-1)), queue[i].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
            }
            newRoom.UpdateRoom(queue[i].neighbour);

            newRoom.name = $"Room ({queue[i].coordinates[0]}, {queue[i].coordinates[1]}, {queue[i].coordinates[2]})";
        }
    }

    bool CheckRoom(int[] coordinates)
    {
        if (coordinates.Length != 3)
        {
            Debug.Log($"Coordinates are only {coordinates.Length} cells large, the function requires 3 coordinates");
            return false;
        }

        bool roomExists = false;
        foreach (Cell room in queue)
        {
            if (room.coordinates[0] == coordinates[0] &&
                room.coordinates[1] == coordinates[1] &&
                room.coordinates[2] == coordinates[2])
            {
                roomExists = true;
                break;
            }
        }

        if (roomExists)
        {
            Debug.Log($"The room exists");
        }
        else
        {
            Debug.Log($"The room doesn't exist");
        }

        return roomExists;
    }

    Cell FindRoom(int[] coordinates)
    {
        if (coordinates.Length != 3)
        {
            Debug.Log($"Coordinates are only {coordinates.Length} cells large, the function needs 3 cells");
        }

        Cell room = null;

        if (CheckRoom(coordinates))
        {
            foreach (Cell scan in queue)
            {
                if (scan.coordinates[0] == coordinates[0] &&
                    scan.coordinates[1] == coordinates[1] &&
                    scan.coordinates[2] == coordinates[2])
                {
                    room = scan;
                    break;
                }
            }
        }

        return room;
    }

    void GetCoordinates()
    {
        int x = 0;
        int y = 0;
        int z = 0;

        bool b_x = false;
        bool b_y = false;
        bool b_z = false;

        while (b_x == false || b_y == false || b_z == false)
        {
            // if 12 is greater than (20 * 0 + 20 / 2) 10 and not less than (20 * 0 - 20 / 2) -10, x++. 
            // if 12 is not greater than (20 * 1 + 20 / 2) 30 and not less than (20 * 1 - 20 / 2) 10, b_x = true.
            // or
            // if -12 is not greater than (20 * 0 + 20 / 2) 10 and less than (20 * 0 - 20 / 2) -10, x--.
            // if -12 is not greater than (20 * -1 + 20 / 2) -10 and not less than (20 * -1 - 20 / 2) -30, b-x = true;
            if (player.transform.position.x > offset.x * x + offset.x / 2) { x++; }
            else if (player.transform.position.x < offset.x * x - offset.x / 2) { x--; }
            else { b_x = true; }

            if (player.transform.position.y > offset.y * y + offset.y / 2) { y++; }
            else if (player.transform.position.y < offset.y * y - offset.y / 2) { y--; }
            else { b_y = true; }

            if (player.transform.position.z > offset.z * z + offset.z / 2) { z++; }
            else if (player.transform.position.z < offset.z * z - offset.z / 2) { z--; }
            else { b_z = true; }
        }

        playerCoordinates = new Vector3(x, y, z);
    }
}
