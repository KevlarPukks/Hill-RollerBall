using UnityEngine;

public class SceneryMover : MonoBehaviour
{
    [SerializeField][Header("The speed of the scenery is this times as much slower")] private float speedDivider =4;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
  
  //Moves scenery at a speed relative to the obstacles
        rb.velocity = ((ObstacleSpawner.obstacleSpeed*100 ) * Time.deltaTime * Vector2.left)/speedDivider;
    }
}
