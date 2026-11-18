using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movement tuning (editable in inspecor)
   public float speed = 5.0f;
    public float turnSpeed;
    // Input system action exposed in inspector for binding (WASD/Arrow keys)
    public InputAction moveAction;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Enabling the Moveaction so it starts reading input
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Rea the 2d vector from the Moveaction (x: horizontal, y: vertical)
        moveInput = moveAction.ReadValue<Vector2>();

        // Move foward/back along local Z using the Y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        // Rotate around local y(yaw) using the x component
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
