using UnityEngine;

public class GoalScorer : MonoBehaviour
{
    // Global score variable
    public static int score = 0;

    // Reference to the pen object
    public GameObject Pen; // Drag your pen object in the Inspector

    // Pen reset position
    public Vector2 penResetPosition = new Vector2(0, -6.5f); // Set to your desired position for the pen
    

    // Movement range for the goal
    public float moveDistance = 2f; // Distance to move the goal each time
    public float minX = -4.5f; // Minimum x position
    public float maxX = 4.5f; // Maximum x position

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the ball
        if (collision.CompareTag("Ball"))
        {
            // Increase the score
            score++;
            Debug.Log("Score: " + score);

            // Reset the ball's position
            ResetBall(collision.gameObject);

            // Move the goal
            MoveGoal();
        }
    }

    private void ResetBall(GameObject ball)
    {
        // Reset the ball's position
        Rigidbody2D pen = Pen.GetComponent<Rigidbody2D>();

        ball.transform.position = new Vector2(0, -5); // Set to your desired position

        // Reset the pen's position
        if (pen != null)
        {
            pen.transform.position = penResetPosition;

            pen.velocity = Vector2.zero;
            pen.angularVelocity = 0;
            pen.transform.rotation = Quaternion.Euler(0, 0, 90);
            
        }

        // Stop the ball's motion
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Reset the velocity
            rb.angularVelocity = 0; // Reset any angular velocity if needed
        }
    }

    private void MoveGoal()
    {
        // Generate a random movement direction
        float randomDirection = Random.Range(-1f, 1f);

        // Calculate the new position
        float newX = transform.position.x + (randomDirection * moveDistance);

        // Clamp the new position to be within the specified range
        newX = Mathf.Clamp(newX, minX, maxX);

        // Move the goal to the new position
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
