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
    void Start()
    {
        StartCoroutine(FoodSpawn(30f, 40f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FoodSpawn(float min, float max)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min, max));

            float xLimUp = transform.position.x + 20 + 2.25f;
            float xLimLow = transform.position.x - 20 - 2.25f;

            float zLimUp = transform.position.z + 20 + 2.25f;
            float zLimLow = transform.position.z - 20 - 2.25f - 4.5f*(Glowbawls.bacchaLog.Count < 6 ? Glowbawls.bacchaLog.Count : 6);

            Vector3 randomSpawnPos = new Vector3(Random.Range(xLimLow, xLimUp), 1.2f, Random.Range(zLimLow, zLimUp));

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
    }
}
