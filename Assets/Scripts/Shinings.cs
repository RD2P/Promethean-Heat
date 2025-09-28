using UnityEngine;

public class Shinings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject PlayerRef;
    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
