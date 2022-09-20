using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour, IMapGenerator
{
    [SerializeField]
    private int xGrid;
    [SerializeField]
    private int yGrid;
    [SerializeField]
    private int density = 1;
    private int[,] mapGrid;

    public int[,] GenerateMap(int brickCount)
    {
        mapGrid = new int[xGrid + 1,yGrid];
        for(int x = 0; x < xGrid/2; x++) {
            for (int y = 0; y < yGrid; y++)
            {
                int random = Random.Range(0, brickCount + 1 + density);
                if (random <= density)
                {
                    mapGrid[x,y] = 0;
                    mapGrid[xGrid - x - 1, y] = 0;
                    continue;
                }
                
                mapGrid[x,y] = random - density;
                if (x == 0)
                {
                    mapGrid[xGrid, y] = random - density;
                    continue;
                }
                mapGrid[xGrid - x, y] = random - density;
            }
        }
        return mapGrid;
    }
}
