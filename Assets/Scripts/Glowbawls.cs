using System.Collections.Generic;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class Glowbawls : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    // public static Baccha[] bacchaLog;
    public static List<Baccha> bacchaLog = new List<Baccha>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        bacchaLog.Clear();
    }
    void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.right * 5);
    }

    // Update is called once per frame
    void Update()
    {
        // if (bacchaLog.Count >= 2)
        // {
        //     lineRenderer.positionCount = bacchaLog.Count;
        //     for (int i = 0; i < bacchaLog.Count; i++)
        //     {
        //         lineRenderer.SetPosition(i, bacchaLog[i].transform.position);
        //     }
        // }

        
    }
}
