using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Garante que o GameObject tenha um componente NavMeshAgent
[RequireComponent(typeof(NavMeshAgent))]
public class FSM : MonoBehaviour
{
    // Enumeração dos estados possíveis: patrulhar ou perseguir
    public enum State { Patrol, Chase }
    private State currentState;

    public GameObject player;                 // Referência ao jogador
    public Transform[] waypoints;            // Pontos de patrulha
    private int currentWaypointIndex = 0;    // Índice do ponto de patrulha atual

    private NavMeshAgent agent;              // Referência ao agente de navegação
    public float distanceMinimun = 10.0f;    // Distância mínima para começar a perseguir
    private bool isNearPlayer = false;       // Indica se o jogador está perto

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   // Pega o componente NavMeshAgent
        currentState = State.Patrol;            // Começa no estado de patrulha
        StartCoroutine(UpdateFSM());            // Inicia a lógica de troca de estados
        GoToNextWaypoint();                     // Vai para o primeiro waypoint
    }

    void Update()
    {
        // Verifica se o jogador está dentro da distância mínima
        isNearPlayer = Vector3.Distance(transform.position, player.transform.position) <= distanceMinimun;

        // Executa o comportamento de acordo com o estado atual
        switch (currentState)
        {
            case State.Patrol:
                Patrol();  // Comportamento de patrulha
                break;
            case State.Chase:
                Chase();   // Comportamento de perseguição
                break;
        }
    }

    // Corroutine que atualiza o estado da FSM periodicamente
    IEnumerator UpdateFSM()
    {
        while (true)
        {
            // Se está patrulhando e o jogador se aproxima, muda para perseguir
            if (currentState == State.Patrol && isNearPlayer)
            {
                currentState = State.Chase;
                Debug.Log("Mudou para Perseguir");
            }
            // Se está perseguindo e o jogador se afasta, volta a patrulhar
            else if (currentState == State.Chase && !isNearPlayer)
            {
                currentState = State.Patrol;
                Debug.Log("Mudou para Patrulhar");
                GoToNextWaypoint();  // Retoma patrulha indo para o próximo ponto
            }

            yield return new WaitForSeconds(0.2f);  // Aguarda 0.2s antes de checar de novo
        }
    }

    // Lógica de patrulha: se chegou ao destino, vai para o próximo ponto
    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }

    // Define o próximo destino de patrulha
    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;  // Se não há waypoints, sai da função

        agent.destination = waypoints[currentWaypointIndex].position;  // Define o destino
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;  // Avança para o próximo, em loop
    }

    // Lógica de perseguição: segue o jogador
    void Chase()
    {
        agent.destination = player.transform.position;
    }
}
