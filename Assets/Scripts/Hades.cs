using UnityEngine;

public class Hades : MonoBehaviour
{
    Animator hadesAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hadesAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( 1 < 2)
        {
            hadesAnimator.SetBool("isWalking", true);
        }
        else
        {
            hadesAnimator.SetBool("isWalking", true);
        }
    }
    }