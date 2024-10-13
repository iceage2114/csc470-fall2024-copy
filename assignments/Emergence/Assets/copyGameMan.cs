/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject cellPrefab;
    CellScript[,] grid;
    float spacing = 1.1f;

    public string[] activeSpeciesList = { "pink", "water", "fire", "honey" }; 
    
    void Start()
    {
        grid = new CellScript[50,50];

        for(int x = 0; x < 50; x++) {
            for(int y = 0; y < 50; y++) {
                Vector3 pos = transform.position;
                pos.x += x * spacing;
                pos.z += y * spacing;
                GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity);
                grid[x,y] = cell.GetComponent<CellScript>();
                grid[x,y].alive = (Random.value > 0.5f);
                grid[x,y].xIndex = x;
                grid[x,y].yIndex = y;

                string randomSpecies = activeSpeciesList[Random.Range(0, activeSpeciesList.Length)];
                grid[x,y].AssignSpecies(randomSpecies);
                grid[x,y].SetColor();
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Simulate();
        }
    }

    void Simulate() {
        bool[,] nextAlive = new bool[50,50];
        List<string>[,] nextSpecies = new List<string>[50,50];

        for(int x = 0; x < 50; x++) {
            for(int y = 0; y < 50; y++) {
                (int count, List<string> neighborSpecies) = CountNeighborsAndSpecies(x, y);
                nextSpecies[x,y] = new List<string>();

                if(grid[x,y].alive && count < 2) {//starving
                    nextAlive[x,y] = false;
                } else if(grid[x,y].alive && (count == 2 || count == 3)) {//surviving
                    nextAlive[x,y] = true;
                    nextSpecies[x,y] = new List<string>(grid[x,y].currentSpecies);
                } else if(grid[x,y].alive && count > 3) {//overcrowding
                    nextAlive[x,y] = false;
                } else if(!grid[x,y].alive && count == 3){ //reproduction
                    nextAlive[x,y] = true;
                    
                    // Check if any neighbor is goo
                    if (neighborSpecies.Contains("goo")) {
                        nextSpecies[x,y].Add("goo");
                    } else {
                        // Handle regular species hybridization
                        var distinctSpecies = neighborSpecies.Distinct().ToList();
                        if (distinctSpecies.Count > 2) {
                            nextSpecies[x,y].Add("goo");
                        } else {
                            nextSpecies[x,y] = distinctSpecies;
                        }
                    }
                } else {
                    nextAlive[x,y] = grid[x,y].alive;
                    if (grid[x,y].alive) {
                        nextSpecies[x,y] = new List<string>(grid[x,y].currentSpecies);
                    }
                }
            }
        }

        for(int i = 0; i < 50; i++) {
            for(int j = 0; j < 50; j++) {
                grid[i,j].alive = nextAlive[i,j];
                grid[i,j].SetSpecies(nextSpecies[i,j]);
                grid[i,j].SetColor();
            }
        }
    }

    public (int count, List<string> species) CountNeighborsAndSpecies(int xIndex, int yIndex)
    {
        int count = 0;
        List<string> neighborSpecies = new List<string>();

        for (int x = xIndex - 1; x <= xIndex + 1; x++)
        {
            for (int y = yIndex - 1; y <= yIndex + 1; y++)
            {
                if (x >= 0 && x < 50 && y >= 0 && y < 50)
                {
                    if (!(x == xIndex && y == yIndex))
                    {
                        if (grid[x,y].alive)
                        {
                            count++;
                            neighborSpecies.AddRange(grid[x,y].currentSpecies);
                        }
                    }
                }
            }
        }

        return (count, neighborSpecies);
    }

    public int CountNeighbors(int xIndex, int yIndex)
    {
        return CountNeighborsAndSpecies(xIndex, yIndex).count;
    }
}*/