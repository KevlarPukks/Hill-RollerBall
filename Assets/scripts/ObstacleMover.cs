using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    /// <summary>
    /// Moves the obstacle from right to left
    /// </summary>
  private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (ObstacleSpawner.obstacleSpeed*100) * Time.deltaTime * Vector2.left;
    }
}
