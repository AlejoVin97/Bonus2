using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        string objectType = other.gameObject.tag;
        switch(objectType){
            case ("Enemy"):
                Destroy(gameObject);
                Destroy(other.gameObject);
                Debug.Log("Player scored!");
                break;
            case ("Player"):
                Debug.Log("Player received damage");
                break;
            default:
                Debug.Log("Undefined collision tag behavior");
                break;
    }
        
    }
}
