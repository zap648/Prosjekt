using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Cell
{
    public Cell() { }
    public Cell(int xCoordinate, int yCoordinate) { coordinates = new int[2] { xCoordinate, yCoordinate }; }

    public int[] coordinates = new int[2];
    public bool[] neighbour = new bool[4]; // 0 - up, 1 - right, 2 - down, 3 - left
    public bool coal = false;
}

public class GruveGenerator : MonoBehaviour
{
    public GameObject room;
    public Vector2 offset;
    public List<Cell> queue;

    void Awake()
    {
        queue = new List<Cell>();
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        int iterations = 0;
        queue.Add(new Cell(0, 0));

        Cell currentCell = queue.Last();

        var newRoom = Instantiate(room, new Vector3(0, 0, 0), Quaternion.Euler(90.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
        newRoom.UpdateRoom(currentCell.neighbour);

        newRoom.name = $"Room 0-0";

        while (iterations < 10 && iterations < queue.Count())
        {
            // To create neighbours
            for (int i = 0; i < 4; i++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    queue[iterations].neighbour[i] = true;

                    if (i == 0) // If the neighbour is above (0 - up)
                    {
                        queue.Add(new Cell(queue[iterations].coordinates[0], queue[iterations].coordinates[1] + 1));
                        queue.Last().neighbour[2] = true;
                    }
                    else if (i == 1) // If the neighbour is rightside (1 - right)
                    {
                        queue.Add(new Cell(queue[iterations].coordinates[0] + 1, queue[iterations].coordinates[1]));
                        queue.Last().neighbour[3] = true;
                    }
                    else if (i == 2) // if the neighbour is below (2 - down)
                    {
                        queue.Add(new Cell(queue[iterations].coordinates[0], queue[iterations].coordinates[1] - 1));
                        queue.Last().neighbour[0] = true;
                    }
                    else if (i == 3) // if the neighbour is leftside (3 - left)
                    {
                        queue.Add(new Cell(queue[iterations].coordinates[0] - 1, queue[iterations].coordinates[1]));
                        queue.Last().neighbour[1] = true;
                    }

                    currentCell = queue.Last();

                    newRoom = Instantiate(room, new Vector3(currentCell.coordinates[0] * offset.x, 0, currentCell.coordinates[1] * offset.y), Quaternion.Euler(90.0f, 0.0f, 0.0f), transform).GetComponent<RoomBehaviour>();
                    newRoom.UpdateRoom(currentCell.neighbour);

                    newRoom.name = $"Room {currentCell.coordinates[0]} - {currentCell.coordinates[1]}";
                }
            }
            iterations++;
        }
    }
}
