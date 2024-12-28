
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float zClampRange = 5f;


    Vector2 movement;
    Rigidbody rb;
    
    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() 
    {
        HandleMovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClampRange, xClampRange);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClampRange, zClampRange);


        rb.MovePosition(newPosition);
    }
}
