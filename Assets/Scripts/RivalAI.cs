using System.Collections;
using UnityEngine;

public class RivalAI : MonoBehaviour
{
    [SerializeField] private BallManager ballManager;
    [SerializeField] private float speed = 5f;
    private enum stateAI
    {
        Idle,
        Moving
    }
    private stateAI curentState = stateAI.Idle;
    private float target = 0f;
    private float direction = 0f;
    private Rigidbody2D rbRival;
    private bool isMoving = false;
    private bool shouldMove = false;
    void Start()
    {
        rbRival = GetComponent<Rigidbody2D>();
    }
    
    IEnumerator movement()
    {
        isMoving = true;
        target = target - rbRival.transform.position.y; // Calculate the difference between the target position and the current position of the rival
        if (target > 1f) 
        {
            direction = 1f;
        }else if (target < -1f)
        {
            direction = -1f;
        }
        else
        {
            direction = 0f;
            shouldMove = false; // Set the shouldMove flag to false if the rival is close enough to the target position, indicating that it should stop moving
        }
        yield return new WaitForSeconds(0.2f); // Wait for 0.5 seconds before allowing the rival to change direction again
        isMoving = false;
    }

    // This function checks the positions of all the balls in the ballManager's ballList and returns the Y position of the nearest ball to the rival
    void CheckBalls()
    {
        float nearest = 0f;
        foreach (GameObject ball in ballManager.ballList)
        {
            if (ball != null)
            {
                if (ball.transform.position.x > nearest)
                {
                    nearest = ball.transform.position.y; // Update the nearest variable to the Y position of the current ball if it is greater than the current value of nearest
                }
                if (ball.transform.position.x>0) shouldMove = true; // Set the shouldMove flag to true if there is at least one ball with a positive X position, indicating that the rival should start moving towards the balls
            }
        }
        target = nearest; // the Y position of the nearest ball
    }
    // Update is called once per frame
    void Update()
    {
        CheckBalls();
        switch (curentState)
        {
            case stateAI.Idle:
                if (shouldMove)
                {
                    curentState = stateAI.Moving; // Change the current state to Follow if the target is not 0
                }
                break;
            case stateAI.Moving:
                if (!isMoving)
                {
                    StartCoroutine(movement());
                }
                if (!shouldMove)
                {
                    curentState = stateAI.Idle; // Change the current state to Idle if the target is 0
                }
                break;
        }
    }
    private void FixedUpdate()
    {
        rbRival.linearVelocityY = direction * speed; // Set the velocity of the Rigidbody2D based on the direction and speed
    }
}
