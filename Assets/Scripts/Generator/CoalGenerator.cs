using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CoalGenerator : MonoBehaviour
{
    [Tooltip("Cave Generation Script")]
    [SerializeField] GruveGenerator gruveGenerator;

    [Tooltip("Average coal per room")]
    [SerializeField] int coalConsentration;

    [Tooltip("Coal info")]
    [SerializeField] GameObject coal;
    [SerializeField] GameObject rock;
    [SerializeField] public List<GameObject> coals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gruveGenerator = GetComponent<GruveGenerator>();
        GenerateCoal();
    }

    void GenerateCoal()
    {
        // Marks which rooms should have coal
        for (int i = 0; i < gruveGenerator.queue.Count(); i++)
        {
            Cell currentCell = gruveGenerator.queue[i];
            // If the current cell is either an elevator or entrance room, don't spawn coal in it
            if (currentCell.roomType == 1 ||
                currentCell.roomType == 2)
            {
                currentCell.coal = false;
                Debug.Log($"Coal in room {gruveGenerator.queue[i].coordinates[0]} - {gruveGenerator.queue[i].coordinates[1]} - {gruveGenerator.queue[i].coordinates[2]}, has been blocked due to being part of an elevator structure.");
                continue;
            }

            // Let's say around half of the room gets coal
            if (Random.value <= 0.50f)
            {
                currentCell.coal = true;
            }
            else
            {
                currentCell.coal = false;
            }
        }

        // Instantiates the coal
        for (int i = 0; i < gruveGenerator.queue.Count(); i++)
        {
            Cell currentCell = gruveGenerator.queue[i];
            if (currentCell.coal == true)
            {
                for (int j = 0; j < coalConsentration; j++)
                {
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
                        newCoal.GetComponent<CoalInfo>().value = Random.Range(1, 4);
                        coals.Add(newCoal);
                        newCoal.name = $"Coal nr.{j} in ({currentCell.coordinates[0]}, {currentCell.coordinates[1]}, {currentCell.coordinates[2]})";
                    }
                    else
                    {
                        GameObject newCoal = Instantiate(rock,
                            new Vector3(
                                currentCell.coordinates[0] * gruveGenerator.offset.x + Random.Range(-gruveGenerator.offset.x / 2 + 2, gruveGenerator.offset.x / 2 - 2),
                                currentCell.coordinates[2] * (gruveGenerator.offset.z * (-1)),
                                currentCell.coordinates[1] * gruveGenerator.offset.y + Random.Range(-gruveGenerator.offset.y / 2 + 2, gruveGenerator.offset.y / 2 - 2)),
                            Quaternion.Euler(0.0f, 0.0f, 0.0f),
                            transform);
                        newCoal.GetComponent<CoalInfo>().isCoal = false;
                        newCoal.name = $"Rock nr.{j} in ({currentCell.coordinates[0]}, {currentCell.coordinates[1]}, {currentCell.coordinates[2]})";
                    }
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
