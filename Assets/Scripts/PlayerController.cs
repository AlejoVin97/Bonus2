using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
        //velocidad de jugador
    public float speed = 10.0f;
    //Valor de la distancia desde el centro de la pantalla a los bordes
    public float xBorder = 10.0f;

    // Define limite de movimiento en el eje z
    public float zMin = -1;
    public float zMax = 14f;

    //Objeto seleccionado para utilizar como projectil
    public GameObject projectilePrefab;
    //receptor de comandos de usuario
    public InputAction moveAction;
    //campo para identificar el movimiento del jugador
    public Vector2 moveInput;
    //
    public InputAction fireAction;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();    
    }

    // Update is called once per frame
    void Update()
    {
        //Si la posicion del jugador esta en los bordes de la pantalla, evitar que pueda continuar moviendose en esa direccion
        if(transform.position.x > xBorder)
        {
            transform.position = new Vector3(xBorder, transform.position.y,transform.position.z);
        }
        else if (transform.position.x < - xBorder)
        {
            transform.position = new Vector3(-xBorder, transform.position.y, transform.position.z);
        }

        // Comprueba si el jugador supero los limites verticales
        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }

        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }
        //Recibe la entrada del movimiento del jugador
        moveInput = moveAction.ReadValue<Vector2>();

        //Y toma el valor del movimiento lateral para mover al personaje horizontalmente, de acuerdo a la velocidad del personaje.
        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);
        //Z toma el valor del movimiento lateral para mover al personaje verticalmente, de acuerdo a la velocidad del personaje.
        transform.Translate(Vector3.forward * moveInput.y * Time.deltaTime * speed);


        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }



}
