using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text endText;
    public static UIManager instance;

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
    }

    public void SetScoreText(int score){
        scoreText.text = "Score: " + score;
    }

    public void ShowEndText(){
        endText.enabled = true;
        endText.text = "You recovered " + Globals.relics + " relics\nTotal value: " + Globals.score;
    }
}
