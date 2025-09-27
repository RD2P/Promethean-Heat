using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * 2;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= Vector3.right * 2;
        }
    }
}
