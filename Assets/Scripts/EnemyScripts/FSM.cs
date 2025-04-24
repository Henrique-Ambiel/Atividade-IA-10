using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Garante que o GameObject tenha um componente NavMeshAgent
[RequireComponent(typeof(NavMeshAgent))]
public class FSM : MonoBehaviour
{
    // Enumera��o dos estados poss�veis: patrulhar ou perseguir
    public enum State { Patrol, Chase }
    private State currentState;

    public GameObject player;                 // Refer�ncia ao jogador
    public Transform[] waypoints;            // Pontos de patrulha
    private int currentWaypointIndex = 0;    // �ndice do ponto de patrulha atual

    private NavMeshAgent agent;              // Refer�ncia ao agente de navega��o
    public float distanceMinimun = 10.0f;    // Dist�ncia m�nima para come�ar a perseguir
    private bool isNearPlayer = false;       // Indica se o jogador est� perto

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   // Pega o componente NavMeshAgent
        currentState = State.Patrol;            // Come�a no estado de patrulha
        StartCoroutine(UpdateFSM());            // Inicia a l�gica de troca de estados
        GoToNextWaypoint();                     // Vai para o primeiro waypoint
    }

    void Update()
    {
        // Verifica se o jogador est� dentro da dist�ncia m�nima
        isNearPlayer = Vector3.Distance(transform.position, player.transform.position) <= distanceMinimun;

        // Executa o comportamento de acordo com o estado atual
        switch (currentState)
        {
            case State.Patrol:
                Patrol();  // Comportamento de patrulha
                break;
            case State.Chase:
                Chase();   // Comportamento de persegui��o
                break;
        }
    }

    // Corroutine que atualiza o estado da FSM periodicamente
    IEnumerator UpdateFSM()
    {
        while (true)
        {
            // Se est� patrulhando e o jogador se aproxima, muda para perseguir
            if (currentState == State.Patrol && isNearPlayer)
            {
                currentState = State.Chase;
                Debug.Log("Mudou para Perseguir");
            }
            // Se est� perseguindo e o jogador se afasta, volta a patrulhar
            else if (currentState == State.Chase && !isNearPlayer)
            {
                currentState = State.Patrol;
                Debug.Log("Mudou para Patrulhar");
                GoToNextWaypoint();  // Retoma patrulha indo para o pr�ximo ponto
            }

            yield return new WaitForSeconds(0.2f);  // Aguarda 0.2s antes de checar de novo
        }
    }

    // L�gica de patrulha: se chegou ao destino, vai para o pr�ximo ponto
    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }

    // Define o pr�ximo destino de patrulha
    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;  // Se n�o h� waypoints, sai da fun��o

        agent.destination = waypoints[currentWaypointIndex].position;  // Define o destino
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;  // Avan�a para o pr�ximo, em loop
    }

    // L�gica de persegui��o: segue o jogador
    void Chase()
    {
        agent.destination = player.transform.position;
    }
}
