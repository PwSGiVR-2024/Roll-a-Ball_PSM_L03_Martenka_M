using UnityEngine;
using UnityEngine.AI;

public class NPCmove : MonoBehaviour
{
    public Transform[] waypoints; // Waypointy w kszta�cie �semki
    public float waypointTolerance = 0.5f; // Jak blisko musi by�, aby uzna�, �e dotar� do punktu
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextWaypoint();
    }

    void Update()
    {
        // Sprawdzenie, czy agent dotar� do celu
        if (!agent.pathPending && agent.remainingDistance < waypointTolerance)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        // Ustaw cel agenta na nast�pny waypoint
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        // Przejd� do kolejnego waypointa
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
