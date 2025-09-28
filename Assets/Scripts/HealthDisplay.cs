using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    // cached length of health sprites
    int playersCurrentHealth = 5;
    // array of sprites to signify health 
    public List<Image> healthSprites = new List<Image>();  // reference to player
    [SerializeField] public Stack<Image> healthSpritesStack = new Stack<Image>();
    [SerializeField] public Health playerHealth; // reference in inspector 
    [SerializeField] Image referenceSprite;// reference to image 



    void Start()
    {
       

    }

    private void Update()
    {
        //playersCurrentHealth = 5;
        if (healthSprites.Count >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                healthSprites[playersCurrentHealth -1].enabled = false;
                
                //healthSprites.RemoveAt(playersCurrentHealth - 1);
                playersCurrentHealth--;
                Debug.Log("after removing " + healthSprites.Count);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("after ending " + healthSprites.Count);
                //healthSprites.Add(referenceSprite);
                healthSprites[playersCurrentHealth].enabled = true;
               
                playersCurrentHealth++;
               
              
              
            }
        }
    }
}
