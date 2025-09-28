using System;
using UnityEngine;


public class Health : MonoBehaviour
{
    public static event Action onTakeDamage;
    public static event Action onDie;
    [SerializeField] int MAX_HEALTH = 5;
     [SerializeField] int current_Health;

    private void Awake()
    {
        current_Health = MAX_HEALTH;
    }
    public void DealDamage(int damageDealt)
    {
        //if (!isAlive) { return; }
        if (current_Health <= 0)
        { return; }
        {
            onTakeDamage?.Invoke();

            current_Health = Mathf.Max(current_Health - damageDealt, 0); // making sure our health doesn't go negative, if it does set it to 0 otherwise whatever your damage value wass

            if (current_Health == 0)
            {
                onDie?.Invoke();
            }
            // Debug.Log(health);
        }


    }


    public bool CriticalHealthPercentage()
    {
        float remaining_Health_percentage = (float)current_Health / MAX_HEALTH * 100; // Dont forget to cast to float otherwise returning float value will default to 0 since health and max health are ints (learned that hte hard way)
        bool bro_Your_Health_Is_LOW;
        // Debug.Log("remaining health % is " + remaining_Health_percentage);
        if (remaining_Health_percentage <= 20f)
        {
            bro_Your_Health_Is_LOW = true;
        }
        else
        {
            bro_Your_Health_Is_LOW = false;
        }

        return bro_Your_Health_Is_LOW;
    }
    public int getCurrentHealth() => current_Health;
    
    public int getMaxHealth() => MAX_HEALTH;

    public float GetNormalizedHealth() => (float) current_Health / MAX_HEALTH;

    public void SetHealth(int updatedHealthValue)
    {
        current_Health = updatedHealthValue;
    }
}
