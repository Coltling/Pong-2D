using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.InputSystem.InputAction;


public class PlayerContols : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Rigidbody2D rbPlayer;
    private float moveDirection = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext clx)
    {
        moveDirection = clx.ReadValue<Vector2>().y; // Read the vertical component of the input vector
        //Debug.Log("Move Direction: " + moveDirection); // Log the move direction for debugging purposes
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbPlayer.linearVelocityY = moveDirection * speed; // Set the velocity of the Rigidbody2D based on the moveDirection and speed
    }
}
