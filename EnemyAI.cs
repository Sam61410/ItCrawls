using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using UnityEditor.PackageManager;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] FirstPersonController player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    //[SerializeField] ObjectGrab objectGrab;
    [SerializeField] public LayerMask PlayerLayers;
    
    public Transform[] waypoints;

    [SerializeField] float playerRadius = 0.28f;
    [SerializeField] float chaseRadius = .4f;
    public float waypointTolerance = 0.5f;

    public int currentPointIndex = 0;
    private int currentWaypointIndex = 0;

    public bool playerFound = false;
    public bool waited = false;
    public bool loopPatrol = true;
    public bool shouldWait = false;
    public void Update()
    {
        PlayerCheck();
        if (playerFound)
        {
            agent.SetDestination(player.transform.position);
            agent.acceleration = 7;
            agent.speed = 5;
            animator.speed = 2;
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance <= waypointTolerance && !playerFound)
            {
                AdvanceWaypoint();
                SetNextDestination();
            }
            else return;
        }
     }
    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (playerFound) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        Gizmos.DrawSphere(
        new Vector3(transform.position.x, transform.position.y, transform.position.z),playerRadius);
    }
    private void PlayerCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        playerFound = Physics.CheckSphere(spherePosition, playerRadius, PlayerLayers);
    }

    public void Start()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            enabled = false;
            return;
        }
        SetNextDestination();
    }
    private void SetNextDestination()
    {
        if (waypoints.Length == 0) return;
        agent.acceleration = 5;
        agent.speed = 3.5f;
        animator.speed = 1;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        if (waited = true && targetWaypoint != null )
        {
            waited = false;
            shouldWait = true;
            agent.SetDestination(targetWaypoint.position);
            animator.Play("Crawl");
        }
    }
    private void AdvanceWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            if (loopPatrol)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                enabled = false; 
            }
        }
    }
}


    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (playerFound) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(
        new Vector3(transform.position.x, transform.position.y, transform.position.z),playerRadius);
    }
    private void PlayerCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        playerFound = Physics.CheckSphere(spherePosition, playerRadius, PlayerLayers); //,QueryTriggerInteraction.Ignore);
    }

    void Start()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            enabled = false;
            return;
        }
        SetNextDestination();
    }
    private void SetNextDestination()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        if (targetWaypoint != null)
        {
            agent.SetDestination(targetWaypoint.position);
            animator.Play("Crawl");
        }
    }
    private void AdvanceWaypoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex >= waypoints.Length)
        {
            if (loopPatrol)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                enabled = false; 
            }
        }
    }
}

