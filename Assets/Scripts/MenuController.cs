using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void StartGame(){
        Globals.score = 0;
        Globals.relics = 0;
        SceneManager.LoadScene(1);
    }

    public void Options(){
        //SceneManager.LoadScene("Main");
    }

    public void CloseGame(){
        Application.Quit();
    }
}
