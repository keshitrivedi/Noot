using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawnner : MonoBehaviour
{
    private static int[] holdingCapacities = {2, 3, 4, 5, 6, 8};
    [SerializeField] private Mush[] mushroomprefabs = {};
    private Dictionary<int, Mush> mushroomcats;

    void Awake()
    {
        mushroomcats = new Dictionary<int, Mush>();
        if (holdingCapacities.Length == mushroomprefabs.Length)
        {
            int idx = 0;
            foreach (var caps in holdingCapacities)
            {
                mushroomcats[caps] = mushroomprefabs[idx];
                mushroomprefabs[idx].capacity = caps;
                idx++;
            }
        }

    }

    public void InstantiateMush(Vector3 randomSpawnPos)
    {
        int points = Random.Range(1, 101);
        Mush selectedMush;

        if (points <= 60)
        {
            selectedMush = Random.value < 0.4f ? mushroomcats[holdingCapacities[0]] : mushroomcats[holdingCapacities[1]];
        } else if(points > 60 && points <= 95)
        {
            selectedMush = Random.value < 0.4f ? mushroomcats[holdingCapacities[2]] : mushroomcats[holdingCapacities[3]];
        } else
        {
            selectedMush = Random.value < 0.4f ? mushroomcats[holdingCapacities[4]] : mushroomcats[holdingCapacities[5]];
        }

        Instantiate(selectedMush, randomSpawnPos, Quaternion.identity);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
