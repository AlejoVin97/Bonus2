using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Valor del borde superior
    private float topBorder = 30.0f;
    //Valor del borde inferior
    private float bottomBorder = -10.0f;
    // Referencia al script GameManager (UI)
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Encontrar el GameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si la posicion del objeto esta en los bordes de la pantalla, evitar que pueda continuar moviendose en esa direccion
        if (transform.position.z > topBorder)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < bottomBorder)
        {
            // Suma -1 para que se vayan descontando vidas
            gameManager.AddLives(-1);
            Destroy(gameObject);
            
        }
    }
}
