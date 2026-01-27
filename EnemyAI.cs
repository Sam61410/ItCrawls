using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using JetBrains.Annotations;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] FirstPersonController player;
    [SerializeField] NavMeshAgent agent;
    public bool playerFound = false;

   // public float GroundedOffset = -0.14f;
    [SerializeField] float playerRadius = 0.28f;

    [SerializeField] public LayerMask PlayerLayers;

    public void Update()
    {
        PlayerCheck();
        if (!playerFound)
        {
            Patrol();
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
    }
    
    public void Patrol()
    { 
            
    }
    public void FindPlayer()
    {
        
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
}
