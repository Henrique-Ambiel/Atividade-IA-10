using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento

    // Update é chamado uma vez por quadro
    void Update()
    {
        // Pegando as entradas das setas do teclado
        float horizontal = Input.GetAxis("Horizontal"); // A, D ou setas esquerda/direita
        float vertical = Input.GetAxis("Vertical"); // W, S ou setas cima/baixo

        // Movendo o player com base nas entradas
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        // Aplicando o movimento no player
        transform.Translate(movement);
    }
}