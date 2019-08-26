using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab used for the obstacle")]
    [SerializeField]private GameObject obstaclePrefab;
   [Header("Time between each spawn")]
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float obstacleStartSpeed = 1f;
    public static float obstacleSpeed;
    [SerializeField] private bool increaseSpawnSpeed =true;
    [Header("Use this to increase the ball speed over time")]
    [SerializeField] private bool increaseObstacleSpeed =true;
    [Header("The acceleration of the ball rolling")]
    [SerializeField] private float speedIncrease = 0.05f;
    private float countdown;//countdown used to  spawn next obstacle
    
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = spawnTime;
        obstacleSpeed = obstacleStartSpeed;
        //if increaseSpawnSpeed is slected in editor spawn first obstacle
        if(increaseSpawnSpeed) Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
       
    }

    // Update is called once per frame
    void Update()
    {
     
        
      
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        if (increaseObstacleSpeed)
        {
            //increases obstacle speed to appear like the ball is rolling faster
            obstacleSpeed += speedIncrease * Time.deltaTime;
        }
        else
        {
            obstacleSpeed = 1;
        }

        //formula used to keep the obstacles appearing without the gaps getting bigger
        var obstacleSpeedIncrease = obstacleStartSpeed / obstacleSpeed;
        var spawnTimeIncrease = spawnTime;
        if (increaseSpawnSpeed)
        {
            spawnTimeIncrease = spawnTime * obstacleSpeedIncrease;
        }


        countdown -= Time.deltaTime;

        if (countdown < 0f)
        {
            //spawn an obstacle when countdown reaches zero and reset countdown 
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            countdown = Random.Range(spawnTimeIncrease - 1f * obstacleSpeedIncrease,
                spawnTimeIncrease + 2f * obstacleSpeedIncrease);
        }
    }
}
