using System.Data.Common;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Baccha : MonoBehaviour
{
    public int id = -1;
    private Transform bacchaTransform;
    private Transform mummiTransform;

    private Animator mummiAnimator;
    private Animator bacchaAnimator;

    private Yellow_movement_game mummiMovementScript;

    [SerializeField] private GameObject mummi;

    private NavMeshAgent navMeshAgent;
    // private bool isAdopted = false;

    private Adoption adoptionScript;

    void Adopt()
    {
        id = Glowbawls.bacchaLog.Count;
        Glowbawls.bacchaLog.Add(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bacchaTransform = GetComponent<Transform>();
        mummiTransform = mummi.GetComponent<Transform>();
        mummiAnimator = mummi.GetComponent<Animator>();
        bacchaAnimator = GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.acceleration = 100f;
        navMeshAgent.angularSpeed = 1000f;
        navMeshAgent.stoppingDistance = 5f;
        navMeshAgent.autoBraking = true;

        mummiMovementScript = mummi.GetComponent<Yellow_movement_game>();

        adoptionScript = GetComponentInChildren<Adoption>();
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         isAdopted = true;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        bacchaTransform.LookAt(mummi.transform);

        bool mummiWalkStatus = mummiAnimator.GetBool("IsWalking");
        if (adoptionScript.isAdopted)
        {

            bacchaAnimator.SetBool("isBacchaWalking", mummiWalkStatus);

            if (id == 0)
            {
                navMeshAgent.destination = mummiTransform.position;
            } else
            {
                // navMeshAgent.destination = Glowbawls.bacchaLog.Peek().transform.position;
                navMeshAgent.destination = Glowbawls.bacchaLog[id - 1].transform.position;
            }

            if (id == -1)
            {
                Adopt();
            }

            if (mummiWalkStatus == false)
            {
                navMeshAgent.speed = 0;
            } else
            {
                navMeshAgent.speed = 15f;
            }

            if (mummiMovementScript.isSprinting)
            {
                navMeshAgent.speed = 20f;
            }
            float mummiBacchaDist = Vector3.Distance(mummiTransform.position, bacchaTransform.position);
            Debug.Log(mummiBacchaDist);
            
        }
        
    }
}
