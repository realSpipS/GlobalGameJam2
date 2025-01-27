using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey){
            int currScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currScene + 1);
        }
    }
}
