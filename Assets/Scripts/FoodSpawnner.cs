using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using System.Collections;

public class FoodSpawnner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static int[] weightCategories = {2, 3, 5, 7, 40};
    [SerializeField] private Collectible[] foodprefabs = {};
    private Dictionary<int, Collectible> weightcats;
    void Awake()
    {
        weightcats = new Dictionary<int, Collectible>();
        if (weightCategories.Length == foodprefabs.Length)
        {
            int idx = 0;
            foreach (var category in weightCategories)
            {
                weightcats[category] = foodprefabs[idx];
                foodprefabs[idx].weight = category;
                idx++;
            }
        }
    }

    public void InstantiateFood(Vector3 randomSpawnPos)
    {
        int points = Random.Range(1, 101);
        Collectible selectedFood;

        if (points <= 60)
        {
            selectedFood = Random.value < 0.5f ? weightcats[weightCategories[0]] : weightcats[weightCategories[1]];
        } else if(points > 60 && points <= 95)
        {
            selectedFood = Random.value < 0.5f ? weightcats[weightCategories[2]] : weightcats[weightCategories[3]];
        } else
        {
            selectedFood = weightcats[weightCategories[4]];
        }

        Instantiate(selectedFood, randomSpawnPos, Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}