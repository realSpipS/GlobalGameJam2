using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target){
            float dist = target.transform.position.y - transform.position.y;
            transform.position +=  new Vector3(0, dist, 0) * Time.deltaTime * speed;
        }
    }
}
