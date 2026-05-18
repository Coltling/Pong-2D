using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    public ScoreManager sManager;
    private Rigidbody2D rbBall;
    private float speed = 5f;
    private float targetSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        float randomX = UnityEngine.Random.Range(-1f, 1f); // Generate a random X component for the initial velocity
        float angle = UnityEngine.Random.Range(-1f, 1f); // Generate a random Y component for the initial velocity
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        if (randomX < 0f) rbBall.AddForce(new Vector2(direction.x,direction.y).normalized * speed,ForceMode2D.Impulse); // Set the initial velocity to the left if randomX is negative
        else rbBall.AddForce(new Vector2(-1*direction.x, direction.y).normalized * speed,ForceMode2D.Impulse); // Set the initial velocity to the right if randomX is positive
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        float offsetY = col.GetContact(0).point.y - col.transform.position.y; // Calculate the offset of the collision point from the center of the object that the ball collided with
        targetSpeed = rbBall.linearVelocity.magnitude;
        rbBall.AddForce(new Vector2(col.GetContact(0).normal.x, offsetY)*2f, ForceMode2D.Impulse); // Add a force to the ball in the direction of the collision normal, with a magnitude based on the offset of the collision point from the center of the object
        rbBall.linearVelocity = rbBall.linearVelocity.normalized * targetSpeed * 1.1f; // Increase the speed of the ball by 10% after each collision, while maintaining its direction
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Goal A")
        {
            sManager.scoreGoal(1); // Increment the score for player B when the ball collides with Goal A
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Goal B")
        {
            sManager.scoreGoal(0); // Increment the score for player A when the ball collides with Goal B
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        rbBall.linearVelocity = Vector2.ClampMagnitude(rbBall.linearVelocity, 15f); // Limit the maximum speed of the ball to 15 units per second
    }
}