using UnityEngine;
using UnityEngine.UI;

public class LevelDoor : MonoBehaviour
{
    public float ShiningCrestNeeded;

    [SerializeField] public Sprite[] doorStates;

    public SpriteRenderer doorRenderer;
    public bool canPassThrough; 
    private void OnEnable()
    {
        Shinings.UpdateDoor += Shinings_UpdateDoor;
    }

 
    private void OnDisable()
    {
        Shinings.UpdateDoor -= Shinings_UpdateDoor;
    }

    private void Shinings_UpdateDoor()
    {
        var playerReference = GameObject.FindGameObjectWithTag("Player");
        if(playerReference != null)
        {
            if(playerReference.GetComponent<PlayerScript>() != null)
            {
                if (playerReference.GetComponent<PlayerScript>().GetShiningCount() >= ShiningCrestNeeded)
                {
                    doorRenderer.sprite = doorStates[1];
                    canPassThrough = true; 
                }
            }
        }
    }

    void Start()
    {
        doorRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canPassThrough == true)
        {
           var NextLevel = GameObject.FindGameObjectWithTag("LevelManager");
           if( NextLevel.GetComponent<LevelManager>() != null)
            {
                NextLevel.GetComponent<LevelManager>().Load_Game_Scene();
            }
        }
    }
}
