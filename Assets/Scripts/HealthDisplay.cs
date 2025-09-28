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

    bool triggerDamage; 

    private void OnEnable()
    {
        Health.onTakeDamage += Health_onTakeDamage;
    }

    private void Health_onTakeDamage()
    {
       triggerDamage = true;
    }

    private void OnDisable()
    {
        Health.onTakeDamage -= Health_onTakeDamage;
    }

    private void Update()
    {
        //playersCurrentHealth = 5;
        if (healthSprites.Count >= 0)
        {
            if (triggerDamage == true)
            {
                healthSprites[playersCurrentHealth -1].enabled = false;
                
                //healthSprites.RemoveAt(playersCurrentHealth - 1);
                playersCurrentHealth--;
                Debug.Log("after removing " + healthSprites.Count);
                triggerDamage = false; 
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
