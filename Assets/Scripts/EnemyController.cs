using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int lifes;
    private bool isDead;
    protected bool isAttacking;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent(out Bubble bubble)){
            bubble.Pop();
        }
    }
}
