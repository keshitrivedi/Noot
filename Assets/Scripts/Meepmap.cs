using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GridCell
{
    public Vector2Int coordinates;
    public bool isOccupied;

    public GridCell(Vector2Int coordinates)
    {
        this.coordinates = coordinates;
        isOccupied = false;
    }
}
public class Meepmap : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    [SerializeField] private FoodSpawnner foodSpawnner;
    private float terrainWidth;
    int cellCount = 20;
    private float cellWidth;

    // List<GridCell> grid = new List<GridCell>();
    private GridCell[,] grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        grid = new GridCell[cellCount, cellCount];
        terrainWidth = terrain.terrainData.size.x;

        cellWidth = terrainWidth / cellCount;
    }
    void Start()
    {
        
    }

    void MushroomMapper()
    {
        for (int z = 0; z < cellCount/2; z+=2)
        {
            for (int x = 0; x < cellCount/2; x+=2)
            {
                if (UnityEngine.Random.Range(0, 5) == 0)
                {
                    // Call MushroomSpawnner ^-^
                    grid[x, z].isOccupied = true;
                    grid[x + 1, z].isOccupied = true;
                    grid[x, z + 1].isOccupied = true;
                    grid[x + 1, z + 1].isOccupied = true;
                    
                }
            }
        }


    }
    void KhaanaMapper()
    {
        for (int z = 0; z < cellCount; z++)
        {
            for (int x = 0; x < cellCount; x++)
            {
                if (UnityEngine.Random.Range(0, 5) == 0)
                {
                    UnityEngine.Vector3 randomSpawnPos = new UnityEngine.Vector3(x * cellWidth, 0, z * cellWidth);
                    // Call FoodSpawnner ^-^
                    foodSpawnner.InstantiateFood(randomSpawnPos);
                    grid[x, z].isOccupied = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
