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

    public GameObject mummi;

    private NavMeshAgent navMeshAgent;
    // private bool isAdopted = false;

    private Adoption adoptionScript;

    public bool isDiscarded = false;

    void Adopt()
    {
        id = Glowbawls.bacchaLog.Count;
        Glowbawls.bacchaLog.Add(this);
        // Debug.Log("Adopt called, id: " + id);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        id = -1;
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
            Debug.Log("Adopteddd");
            // bacchaAnimator.SetBool("isBacchaWalking", mummiWalkStatus);

            if (id == -1)
            {
                Adopt();
            }

            if (!this.isDiscarded) {
                bacchaAnimator.SetBool("isBacchaWalking", mummiWalkStatus);
                if (Glowbawls.bacchaLog.IndexOf(this) == 0)
                {
                    navMeshAgent.destination = mummiTransform.position;
                } else
                {
                    // navMeshAgent.destination = Glowbawls.bacchaLog.Peek().transform.position;
                    navMeshAgent.destination = Glowbawls.bacchaLog[Glowbawls.bacchaLog.IndexOf(this) - 1].transform.position;
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
            }
            // float mummiBacchaDist = Vector3.Distance(mummiTransform.position, bacchaTransform.position);
            // Debug.Log(mummiBacchaDist);
            
            
        }
        // Debug.Log($"Count: {Glowbawls.bacchaLog.Count}");
        Debug.Log(navMeshAgent.remainingDistance);
        Debug.Log(navMeshAgent.desiredVelocity);
    }
}
