using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h_mov = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v_mov = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(h_mov * speed, v_mov * speed, 0);
    }
}
