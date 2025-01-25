using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    public Vector2 mousePos;
    private void FixedUpdate() {
        mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;

        float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        if (dir.x < 0) transform.rotation = Quaternion.Euler(180, 0, -AngleDeg);
        else transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
