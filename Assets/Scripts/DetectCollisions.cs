using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Referencia al script GameManager (UI)
    private GameManager gameManager;
    public int objectHp = 0; //Cantidad de toques para que el objeto desaparezca de la escena

    void Start()
    {
        // Encontrar el GameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Reacciona al choque de un enemigo con otro objecto
    private void OnTriggerEnter(Collider other)
    {

        string objectType = other.gameObject.tag; //La tag del objeto con el cual se choco 
        switch (objectType)
        {
            //si se choco con un ataque
            case ("Attack"):
                other.gameObject.SetActive(false); //se desactiva el ataque
                objectHp -= 1;
                //y si el hambre del enemigo llega a 0, se remueve al enemigo y se añade 1 al puntaje del jugador
                if (objectHp == 0)
                {
                    Destroy(gameObject);
                    gameManager.AddScore(1);
                }
                break;//Fin de Caso:Ataque

            //si se choco con el jugador
            case ("Player"):

                gameManager.AddLives(-1); //se le quita una vida al jugador
                
                break;

            //si se choco con algun otro objeto
            default:
                Debug.Log("Undefined collision tag behavior");//No esta definido el comportamiento, solo registra que sucedio
                break;

        }

    }

}
