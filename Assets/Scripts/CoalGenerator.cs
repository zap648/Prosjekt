using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using static CaveGenerator;

public class CoalGenerator : MonoBehaviour
{
    [Tooltip("Cave Generation Script")]
    [SerializeField] CaveGenerator caveGenerator;

    [Tooltip("Average coal per room")]
    [SerializeField] int coalConsentration;

    [Tooltip("Coal info")]
    [SerializeField] GameObject coal;
    [SerializeField] public List<GameObject> coals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        caveGenerator = GetComponent<CaveGenerator>();
        GenerateCoal();
    }

    void GenerateCoal()
    {
        // Marks which rooms should have coal
        for (int i = 0; i < caveGenerator.board.Count; i++)
        {
            // If the current cell is the first cell, don't spawn coal in it
            if (caveGenerator.board[i] == caveGenerator.board.First())
                continue;

            // Let's say around half of the room gets coal
            if (Random.value <= 0.50f && caveGenerator.board[i].visited)
            {
                caveGenerator.board[i].coal = true;
            }
        }

        // Instantiates the coal
        for (int i = 0; i < caveGenerator.size.x; i++)
        {
            for (int j = 0; j < caveGenerator.size.y; j++)
            {
                Cell currentCell = caveGenerator.board[Mathf.FloorToInt(i + j * caveGenerator.size.x)];
                if (currentCell.coal)
                {
                    GameObject newCoal = Instantiate(coal, new Vector3(i * caveGenerator.offset.x + Random.Range(-caveGenerator.size.x, caveGenerator.size.x), 0, -j * caveGenerator.offset.y + Random.Range(-caveGenerator.size.y, caveGenerator.size.y)), Quaternion.Euler(0.0f, 0.0f, 0.0f), transform);
                    coals.Add(newCoal);
                    newCoal.name = $"Coal in {i}-{j}";
                }
            }
        }
    }
}
