using UnityEngine;

public class Relic : MonoBehaviour
{
    [SerializeField] int value = 5;
    GameObject bubble = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetValue(){
        return value;
    }

    public void SetBubble(GameObject bubble){
        this.bubble = bubble;
    }

    private void OnDestroy() {
        if (bubble) Destroy(bubble);
    }
}
