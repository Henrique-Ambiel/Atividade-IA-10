using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FSM : MonoBehaviour
{
    public enum State { Patrol, Chase }
    private State currentState;

    public GameObject player;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private NavMeshAgent agent;
    public float distanceMinimun = 10.0f;
    private bool isNearPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = State.Patrol;
        StartCoroutine(UpdateFSM());
        GoToNextWaypoint();
    }

    void Update()
    {
        isNearPlayer = Vector3.Distance(transform.position, player.transform.position) <= distanceMinimun;

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
        }
    }

    IEnumerator UpdateFSM()
    {
        while (true)
        {
            if (currentState == State.Patrol && isNearPlayer)
            {
                currentState = State.Chase;
                Debug.Log("Mudou para Perseguir");
            }
            else if (currentState == State.Chase && !isNearPlayer)
            {
                currentState = State.Patrol;
                Debug.Log("Mudou para Patrulhar");
                GoToNextWaypoint();
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void Chase()
    {
        agent.destination = player.transform.position;
    }
}
