using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShiningsCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counter;
    public int counterIndex = 0;
    GameObject playeref; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playeref = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playeref != null)
        {
            if (playeref.GetComponent<PlayerScript>() != null)
            {
                counterIndex = playeref.GetComponent<PlayerScript>().GetShiningCount();
            }
        }
        
        counter.text = counterIndex.ToString();
    }
}
