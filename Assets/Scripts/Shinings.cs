using System;
using UnityEngine;

public class Shinings : MonoBehaviour
{
    public static event Action UpdateDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject PlayerRef;

    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerScript>())
            {
                other.gameObject.GetComponent<PlayerScript>().SetShiningCount(1);
            }
            UpdateDoor?.Invoke();
            Destroy(gameObject);
        }
        else { return; }
    }

}
