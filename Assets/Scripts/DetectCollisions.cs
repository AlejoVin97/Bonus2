using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        gameManager.AddScore(1);
    }
}
