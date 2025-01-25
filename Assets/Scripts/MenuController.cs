using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void Options(){
        //SceneManager.LoadScene("Main");
    }

    public void CloseGame(){
        //SceneManager.LoadScene("Main");
    }
}
