using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Valor del borde superior
    private float topBorder = 30.0f;
    //Valor del borde inferior
    private float bottomBorder = -10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Debug.Log("Game Over!");
            Destroy(gameObject);
            
        }
    }
}
