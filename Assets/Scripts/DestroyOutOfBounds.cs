using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Valor del borde superior
    private float topBorder = 30.0f;
    //Valor del borde inferior
    private float bottomBorder = -10.0f;

    //Valor de los limites horizontales
    public float xBorder = 25.0f;

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
        //Si la posicion del objeto esta en los bordes de la pantalla
        if (transform.position.z > topBorder)
        {
            // Desactivarlo, porque es uno de nuestros objetos pooleados
            gameObject.SetActive(false);

        }
        else if (transform.position.z < bottomBorder || Mathf.Abs(transform.position.x) > xBorder )//De lo contrario, si llega a cualquier otro de los limites, es porque es un animal
        {
            // Suma -1 para que se vayan descontando vidas, y se remueve este animal
            gameManager.AddLives(-1);
            Destroy(gameObject);

        }

    }
}
