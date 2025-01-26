using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text endText;
    [SerializeField] Slider airBar;
    public static UIManager instance;
    Player player;

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
}
