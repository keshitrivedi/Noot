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
    [SerializeField] private MushroomSpawnner mushroomSpawnner;
    private float terrainWidth;
    int cellCount = 40;
    private float cellWidth;

    // List<GridCell> grid = new List<GridCell>();
    private GridCell[,] grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        grid = new GridCell[cellCount, cellCount];

        for (int z = 0; z < cellCount; z++)
        {
            for (int x = 0; x < cellCount; x++)
            {
                grid[x, z] = new GridCell(new Vector2Int(x, z));
            }
        }

        terrainWidth = terrain.terrainData.size.x;

        cellWidth = terrainWidth / cellCount;
    }
    void Start()
    {
        MushroomMapper();
        KhaanaMapper();
    }

    void MushroomMapper()
    {
        for (int z = 0; z < cellCount/2; z+=2)
        {
            for (int x = 0; x < cellCount/2; x+=2)
            {
                if (UnityEngine.Random.Range(0, 5) == 0)
                {
                    UnityEngine.Vector3 randomSpawnPos = new UnityEngine.Vector3(x * cellWidth, -0.1f, z * cellWidth);
                    // Call MushroomSpawnner ^-^
                    mushroomSpawnner.InstantiateMush(randomSpawnPos);
                    Debug.Log("musgroen");
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
                if ((UnityEngine.Random.Range(0, 5) == 0) && !grid[x, z].isOccupied)
                {
                    UnityEngine.Vector3 randomSpawnPos = new UnityEngine.Vector3(x * cellWidth, 1.2f, z * cellWidth);
                    // Call FoodSpawnner ^-^
                    foodSpawnner.InstantiateFood(randomSpawnPos);
                    Debug.Log("khana lag gaya hai");
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
