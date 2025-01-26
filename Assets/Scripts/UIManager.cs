using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text endText;
    [SerializeField] Slider airBar;
    [SerializeField] GameObject menu;
    public static UIManager instance;
    Player player;
    bool isMenuOpen = false;

    private void Awake() {
        if (instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
    }

    private void Start() {
        endText.text = "";
        player = FindFirstObjectByType<Player>();
    }

    public void SetScoreText(int score){
        scoreText.text = "Score: " + score;
    }

    public void ShowEndText(){
        endText.enabled = true;
        endText.text = "You recovered " + Globals.relics + " relics\nTotal value: " + Globals.score;
    }

    public void UpdateBar(int maxAmount, int amount){
        airBar.maxValue = maxAmount;
        airBar.value = amount;
    }

    public void Menu(){
        isMenuOpen = !isMenuOpen;
        menu.SetActive(isMenuOpen);
        if (isMenuOpen) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Options(){
        //SceneManager.LoadScene("Main");
    }
}
