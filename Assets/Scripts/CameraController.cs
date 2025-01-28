using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform downLimit;
    [SerializeField] Transform upLimit;
    [SerializeField] float speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (target){
            float dist = target.transform.position.y - transform.position.y;
            transform.position +=  new Vector3(0, dist, 0) * Time.deltaTime * speed;
        }

        if (upLimit){
            if(transform.position.y > upLimit.position.y){
                transform.position = upLimit.position;
            }
        }

        if (downLimit){
            if(transform.position.y < downLimit.position.y){
                transform.position = downLimit.position;
            }
        }
    }
}
