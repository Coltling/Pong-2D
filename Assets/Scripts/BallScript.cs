using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    public ScoreManager sManager;
    private Rigidbody2D rbBall;
    private float speed = 2f;
    private Vector2 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        float randomX = UnityEngine.Random.Range(-1f, 1f); // Generate a random X component for the initial velocity
        float randomY = UnityEngine.Random.Range(-5f, 5f); // Generate a random Y component for the initial velocity
        if (randomX < 0f) rbBall.AddForce(new Vector2(-10 * speed, randomY*10),ForceMode2D.Impulse); // Set the initial velocity to the left if randomX is negative
        else rbBall.AddForce(new Vector2(10 * speed, randomY*10),ForceMode2D.Impulse); // Set the initial velocity to the right if randomX is positive
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        float offsetY = col.GetContact(0).point.y - col.transform.position.y; // Calculate the offset of the collision point from the center of the object that the ball collided with
        rbBall.AddForce(new Vector2(0, offsetY)*2f, ForceMode2D.Impulse);
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
        rbBall.linearVelocity = Vector2.ClampMagnitude(rbBall.linearVelocity, 10f); // Limit the maximum speed of the ball to 10 units per second
    }
}