using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float speed = 1;
    bool main = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        //Vector3 newPos = Vector3(transform.position.x, transform.position.y, 0);
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent(out Bubble bubble)){
            BubbleManager.instance.AddContact(gameObject);
        }
    }

    public bool isMain(){
        return main;
    }
}
