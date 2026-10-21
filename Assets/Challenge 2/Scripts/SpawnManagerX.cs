using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    //Reference numbers for value limits
    //Lower limit for ball spawning in X axis (leftmost along the span of the screen)
    private float spawnLimitXLeft = -22;
    //Higher limit for ball spawning in X axis (rightmost along the span of the screen)
    private float spawnLimitXRight = 7;
    //Ball spawning value in Y (height at which balls are spawned)
    private float spawnPosY = 30;
    //Lower limit for ball spawning interval (the least amount of time between two balls' spawning)
    private float spawnIntervalMin = 3;
    //Higher limit for ball spawning interval (the most amount of time between two balls' spawning)
    private float spawnIntervalMax = 5;

    //The amount of time left before another ball is spawned
    private float spawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the amount of time to spawn the ball
        spawnInterval = Random.Range(spawnIntervalMin,spawnIntervalMax);
        //Then spawns the first ball of the game
        Invoke("SpawnRandomBall", spawnInterval);
    }

    private void Update()
    {   
        //While there's time before another ball is spawned...
        if (spawnInterval > 0)
        {   
            //This time is reduced by the amount of time since the last check
            spawnInterval -= Time.deltaTime;
        }//Otherwise - that is, if there's no more time before the next ball is spawned...
        else
        {
            //Sets up the next ball's spawn
            Invoke("SpawnRandomBall", spawnInterval);
        }
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        //Generates the amount of time before the next ball is spawned
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

        // Generate random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        //Indicates the ball to generate out of the ballPrefabs' array
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

    }

}
