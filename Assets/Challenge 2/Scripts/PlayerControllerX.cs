using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;
    //Specifies the amount of time allowed between player inputs.
    private float inputInterval = 1.5f;
    private float wait = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (fireAction.triggered)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            fireAction.Disable();
            wait = inputInterval;
        }
        else if( wait > 0f )
        {
            wait -= Time.deltaTime;
            if (wait <= 0f)
            {
                fireAction.Enable();
                wait = 0.0f;
            }
        }
        

    
    }
}
