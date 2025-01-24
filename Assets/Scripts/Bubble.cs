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
            Debug.Log(transform.localScale.x + " e " + other.transform.localScale.x);
            if (transform.localScale.x > other.transform.localScale.x){
                transform.localScale += other.transform.localScale/2;
            }
            else{
                Destroy(gameObject);
            }
            //transform.position = Vector3.Normalize(other.collider.transform.position - transform.position) + transform.position;
        }
    }

    public bool isMain(){
        return main;
    }
}
