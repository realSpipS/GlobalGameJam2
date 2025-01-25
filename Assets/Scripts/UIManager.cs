using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public static UIManager instance;

    private void Awake() {
        if (instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreText(int score){
        scoreText.text = "Score: " + score;
    }
}
