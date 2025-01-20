using UnityEngine;
using UnityEngine.AI;

public class NPCmove : MonoBehaviour
{
    public Transform[] waypoints; // Waypointy w kszta³cie ósemki
    public float waypointTolerance = 0.5f; // Jak blisko musi byæ, aby uznaæ, ¿e dotar³ do punktu
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextWaypoint();
    }

    void Update()
    {
        // Sprawdzenie, czy agent dotar³ do celu
        if (!agent.pathPending && agent.remainingDistance < waypointTolerance)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        // Ustaw cel agenta na nastêpny waypoint
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        // PrzejdŸ do kolejnego waypointa
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
