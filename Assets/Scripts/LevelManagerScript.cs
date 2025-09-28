using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Load_Game_Scene()
    {
        int curentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current index is " + curentSceneIdx);

        SceneManager.LoadScene(curentSceneIdx + 1);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Load_Game_Scene();
            Debug.Log("start");
        }
    }
}
