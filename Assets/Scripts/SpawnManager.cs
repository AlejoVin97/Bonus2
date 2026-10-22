using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{   
    //Lista de prefabs a utilizar para los animales a crear
    public GameObject[] animalPrefabs;
    //Recibe entrada para iniciar el juego
    public InputAction spawnAction;
    //Amplitud del rango en el eje X positivo y negativo en el cual pueden generarse enemigos
    private float spawnRangeX = 19.0f;
    //Maximo valor en el eje Z donde pueden generarse enemigos
    private float maxPosZ = 18.0f;
    //Minimo valor en el eje Z donde pueden generarse enemigos
    private float minPosZ = 0.0f;
    
    //Posicion en el eje Z donde se crean enemigos que se mueven bajando por la pantalla.
    private float moveDownAnimalZPos = 20.0f;
    //Posiicon en el eje X donde se crean enemigos que se mueven hacia la derecha de la pantalla
    private float moveRightAnimalXPos = -20.0f;
    //Posiicon en el eje X donde se crean enemigos que se mueven hacia la izquierda de la pantalla
    private float moveLeftAnimalXPos = 20.0f;
    private float animalRotation = 90; //Range of degrees of turn for animal rotation on spawn, based on the prefab's default rotation

    //Retraso al inicio de la generación de enemigos
    private float startDelay = 2;
    //Intervalo de tiempo entre generación de dos enemigos
    private float spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Permite que se pueda recibir el comando para iniciar el juego
        spawnAction.Enable();
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval - 0.5f);
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval - 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Al detectar la entrada para generar enemigos
        if (spawnAction.triggered)
        {
            //Genera un animal aleatorio en una posicion aleatoria en el eje X pero estatica en altura y profunda
            SpawnRandomAnimal();
        }
        */
    }
  
    void SpawnRandomAnimal()
    {
        //se utiliza un indice para acceder a un modelo de animal especifico, y se le asigna un valor aleatorio (entre los valores que se han asignado)
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int animalDirection = Random.Range( 0, 3); //Colocar el animal en una de 3 direcciones de avance (0 = arriba-abajo, 1 = izquierda-derecha, 2=derecha-izquierda)
        Vector3 spawnPos = new Vector3(0, 0, 0) ;
        float spawnRota = 0.0f;
        switch (animalDirection)
        {
            case 0:
                //Se genera una posicion en la cual generar al enemigo, tomando un valor aleatorio en X en el cual generarlo
                spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, moveDownAnimalZPos);
                break;

            case 1:
                //
                spawnPos = new Vector3(moveRightAnimalXPos, 0, Random.Range(minPosZ,maxPosZ));
                spawnRota = -animalRotation;
                break;

            case 2:
                //Se genera una posicion en la cual generar al enemigo, tomando un valor aleatorio en X en el cual generarlo
                spawnPos = new Vector3(moveLeftAnimalXPos, 0, Random.Range(minPosZ, maxPosZ));
                spawnRota = animalRotation;
                break;
            default:
                Debug.Log("Undefined animal position behavior");
                break;

        }

        //Genera el modelo de enemigo especificado por el indice aleatorio
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation * Quaternion.AngleAxis(spawnRota,Vector3.up) );
    }
}
