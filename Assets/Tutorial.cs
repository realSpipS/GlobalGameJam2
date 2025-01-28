using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Text centerText;
    [SerializeField] Image image;
    [SerializeField] Sprite[] screenshots = new Sprite[4];
    string[] tutorial = {"You are an intrepid diver. you must retrieve ancient relics from the ocean floor!",
                    "Press the right mouse button to inflate bubbles and the left mouse button to push them",
                    "Join the bubbles to create ones large enough to inglobe the relics and push them to the surface!",
                    "Press E to suck the oxygen out of the bubbles when you're close enough, but be careful not to touch them or they'll burst!"};


    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centerText.text = tutorial[index];
        image.sprite = screenshots[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")){
            index++;
            if(index >= tutorial.Length){
                int currScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currScene + 1);
                return;
            }
            centerText.text = tutorial[index];
            image.sprite = screenshots[index];
        }
    }
}
