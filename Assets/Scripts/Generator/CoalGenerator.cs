using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class CoalGenerator : MonoBehaviour
{
    [Tooltip("Cave Generation Script")]
    [SerializeField] GruveGenerator gruveGenerator;

    [Tooltip("Average coal per room")]
    [SerializeField] int rockConsentration;

    [Tooltip("Coal info")]
    [SerializeField] GameObject coal;
    [SerializeField] public List<GameObject> coals = new List<GameObject>();
    [SerializeField] int minValue;
    [SerializeField] int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        gruveGenerator = GetComponent<GruveGenerator>();
        GenerateCoal();
    }

    void GenerateCoal()
    {
        // Marks which rooms should have coal
        for (int i = 0; i < gruveGenerator.queue.Count; i++)
        {
            Cell currentCell = gruveGenerator.queue[i];
            // If the current cell is either an elevator or entrance room, don't spawn coal in it
            if (currentCell.roomType == 1 ||
                currentCell.roomType == 2)
            {
                continue;
            }

            // Let's say around half of the room gets coal
            if (Random.value <= 0.50f)
            {
                currentCell.coal = true;
            }
        }

        // Instantiates the coal
        for (int i = 0; i < gruveGenerator.queue.Count(); i++)
        {
            Cell currentCell = gruveGenerator.queue[i];
            if (currentCell.coal == true)
            {
                if (currentCell.roomType == 0)
                {
                    for (int j = 0; j < rockConsentration; j++)
                    {
<<<<<<< Updated upstream
                        GameObject newCoal = Instantiate(coal,
                            new Vector3(
                                currentCell.coordinates[0] * gruveGenerator.offset.x + Random.Range(-gruveGenerator.offset.x / 2 + 2, gruveGenerator.offset.x / 2 - 2),
                                currentCell.coordinates[2] * (gruveGenerator.offset.z * (-1)),
                                currentCell.coordinates[1] * gruveGenerator.offset.y + Random.Range(-gruveGenerator.offset.y / 2 + 2, gruveGenerator.offset.y / 2 - 2)),
                            coal.gameObject.transform.rotation,
                            transform);
                        coals.Add(newCoal);
                        newCoal.GetComponent<CoalInfo>().value = Random.Range(minValue, maxValue);
                        newCoal.name = $"Coal nr.{j} in ({currentCell.coordinates[0]}, {currentCell.coordinates[1]}, {currentCell.coordinates[2]})";
=======
                        if (Random.Range(0, 4) == 0)
                        {
                            GameObject newCoal = Instantiate(coal,
                                new Vector3(
                                    currentCell.coordinates[0] * gruveGenerator.offset.x + Random.Range(-gruveGenerator.offset.x / 2 + 2, gruveGenerator.offset.x / 2 - 2),
                                    currentCell.coordinates[2] * (gruveGenerator.offset.z * (-1)),
                                    currentCell.coordinates[1] * gruveGenerator.offset.y + Random.Range(-gruveGenerator.offset.y / 2 + 2, gruveGenerator.offset.y / 2 - 2)),
                                Quaternion.Euler(0.0f, 0.0f, 0.0f),
                                transform);
                            newCoal.GetComponent<CoalInfo>().isCoal = true;
                            coals.Add(newCoal);
                            newCoal.name = $"Coal nr.{j} in ({currentCell.coordinates[0]}, {currentCell.coordinates[1]}, {currentCell.coordinates[2]})";
                        }
                        else
                        {
                            GameObject newRock = Instantiate(rock,
                                new Vector3(
                                    currentCell.coordinates[0] * gruveGenerator.offset.x + Random.Range(-gruveGenerator.offset.x / 2 + 2, gruveGenerator.offset.x / 2 - 2),
                                    currentCell.coordinates[2] * (gruveGenerator.offset.z * (-1)),
                                    currentCell.coordinates[1] * gruveGenerator.offset.y + Random.Range(-gruveGenerator.offset.y / 2 + 2, gruveGenerator.offset.y / 2 - 2)),
                                Quaternion.Euler(0.0f, 0.0f, 0.0f),
                                transform);
                            newRock.GetComponent<CoalInfo>().isCoal = false;
                            newRock.name = $"Rock nr.{j} in ({currentCell.coordinates[0]}, {currentCell.coordinates[1]}, {currentCell.coordinates[2]})";
                        }
>>>>>>> Stashed changes
                    }
                }
            }
            else
            {
                for (int j = 0; j < rockConsentration; j++)
                {
                    GameObject newRock = Instantiate(rock,
                        new Vector3(
                            currentCell.coordinates[0] * gruveGenerator.offset.x + Random.Range(-gruveGenerator.offset.x / 2 + 2, gruveGenerator.offset.x / 2 - 2),
                            currentCell.coordinates[2] * (gruveGenerator.offset.z * (-1)),
                            currentCell.coordinates[1] * gruveGenerator.offset.y + Random.Range(-gruveGenerator.offset.y / 2 + 2, gruveGenerator.offset.y / 2 - 2)),
                        Quaternion.Euler(0.0f, 0.0f, 0.0f),
                        transform);
                    newRock.GetComponent<CoalInfo>().isCoal = false;
                    newRock.name = $"Rock nr.{j} in ({currentCell.coordinates[0]}, {currentCell.coordinates[1]}, {currentCell.coordinates[2]})";
                }
            }
        }

        // Old instantiate for Cave Generator
        //for (int i = 0; i < gruveGenerator.size.x; i++)
        //{
        //    for (int j = 0; j < gruveGenerator.size.y; j++)
        //    {
        //        Cell currentCell = gruveGenerator.queue[Mathf.FloorToInt(i + j * gruveGenerator.size.x)];
        //        if (currentCell.coal)
        //        {
        //            GameObject newCoal = Instantiate(coal, new Vector3(i * gruveGenerator.offset.x + Random.Range(-gruveGenerator.size.x, gruveGenerator.size.x), 0, -j * gruveGenerator.offset.y + Random.Range(-gruveGenerator.size.y, gruveGenerator.size.y)), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform);
        //            coals.Add(newCoal);
        //            newCoal.name = $"Coal in {i}-{j}";
        //        }
        //    }
        //}
    }
}
