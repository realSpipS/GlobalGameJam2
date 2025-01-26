using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void Options(){
        //SceneManager.LoadScene("Main");
    }

    public void CloseGame(){
        Application.Quit();
    }
}
