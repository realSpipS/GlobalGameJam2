using UnityEngine;

public class MineController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent(out Bubble bubble)){
            bubble.Pop();
        }
        if(other.collider.TryGetComponent(out Player player)){
            player.gotHit = true;
            Destroy(gameObject);

        }
    }


}
