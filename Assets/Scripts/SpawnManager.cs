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
    private float spawnRangeX = 20.0f;
    //Distancia en el eje Z en el cual se generan los enemigos
    private float spawnPosZ = 20.0f;
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
        //Se genera una posicion en la cual generar al enemigo, tomando un valor aleatorio en X en el cual generarlo
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        //Genera el modelo de enemigo especificado por el indice aleatorio
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
