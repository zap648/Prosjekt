using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Cell
{
    public Cell(int xCoordinate, int yCoordinate, int zCoordinate) { coordinates = new int[3] { xCoordinate, yCoordinate, zCoordinate }; }

    public int[] coordinates = new int[3];
    public bool[] neighbour = new bool[4]; // 0 - up, 1 - right, 2 - down, 3 - left
    public int roomType = 0; // 0 - normal, 1 - elevator, 2 - access
    public bool elevator = false;
    public bool coal = false;
}

public class GruveGenerator : MonoBehaviour
{
    [Header("Room Prefabs")]
    public GameObject roomPreFab;
    public GameObject elevRoomPreFab;
    public GameObject accRoomPreFab;

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


    private RoomBehaviour spawnRoom;

    void Awake()
    {
        queue = new List<Cell>
        {
            new Cell(0, 0, 0)
        };

        GenerateDungeon();

        CreateRooms();

        GruveElevator elevator = spawnRoom.GetComponentInChildren<GruveElevator>();
        elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.topHeight, elevator.transform.position.z);

        player = Instantiate(playerPreFab);
        player.transform.position = elevator.transform.position;
        elevator.cargo.Add(player);
        elevator.machine.TransitionTo(elevator.machine.lowerState);
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < floors; i++)
        {
            if (i > 0)
            {
                NewFloor(queue.Last(), i);
            }

            int whileCheck = 0;
            while (queue.Count() - 1 < maxRooms + maxRooms * i)
            {
                SetupNeighbours(queue.Last(), i);

                if (whileCheck > 100)
                {
                    Debug.Log("Endless loop detected! Breaking loop!");
                    break;
                }
            }

            if (queue.Count() < minRooms + minRooms * i)
            {
                GenerateDungeon();
            }
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
        RoomBehaviour newRoom = Instantiate(elevRoomPreFab, new Vector3(queue[0].coordinates[0] * offset.x, queue[0].coordinates[2] * (offset.z * (-1)), queue[0].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
        newRoom.UpdateRoom(queue[0].neighbour);

        newRoom.name = $"Spawn Room";
        spawnRoom = newRoom;

        for (int i = 1; i < queue.Count(); i++)
        {
            if (queue[i].roomType == 0)
            {
                newRoom = Instantiate(roomPreFab, new Vector3(queue[i].coordinates[0] * offset.x, queue[i].coordinates[2] * (offset.z * (-1)), queue[i].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
            }
            else if (queue[i].roomType == 1)
            {
                newRoom = Instantiate(elevRoomPreFab, new Vector3(queue[i].coordinates[0] * offset.x, queue[i].coordinates[2] * (offset.z * (-1)), queue[i].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
                newRoom.gameObject.GetComponentInChildren<GruveElevator>().transform.position = new Vector3(newRoom.gameObject.GetComponentInChildren<GruveElevator>().transform.position.x, newRoom.gameObject.GetComponentInChildren<GruveElevator>().topHeight, newRoom.gameObject.GetComponentInChildren<GruveElevator>().transform.position.z);
                newRoom.gameObject.GetComponentInChildren<GruveElevator>().atTop = true;
            }
            else if (queue[i].roomType == 2)
            {
                newRoom = Instantiate(accRoomPreFab, new Vector3(queue[i].coordinates[0] * offset.x, queue[i].coordinates[2] * (offset.z * (-1)), queue[i].coordinates[1] * offset.y), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
            }
            newRoom.UpdateRoom(queue[i].neighbour);

            newRoom.name = $"Room ({queue[i].coordinates[0]}, {queue[i].coordinates[1]}, {queue[i].coordinates[2]})";
        }
    }

    bool CheckRoom(int[] coordinates)
    {
        if (coordinates.Length != 3)
        {
            Debug.Log($"Coordinates are only {coordinates.Length} cells large, the function needs 3 cells");
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
}
