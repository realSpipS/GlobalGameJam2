using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform finish;
    [SerializeField] float offset = 3.5f;
    [SerializeField] float speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (target){
            float dist = target.transform.position.y - transform.position.y;
            transform.position +=  new Vector3(0, dist, 0) * Time.deltaTime * speed;
        }

        if (finish){
            if(transform.position.y >= finish.position.y - offset){
                transform.position = new Vector3(transform.position.x, finish.position.y - offset, -10);
            }
        }
    }
}
