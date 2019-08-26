using UnityEngine;

public class ScaleIncrease : MonoBehaviour
{
    [SerializeField][Header("Scale increase amount over time")] private float increaseAmount = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //increases the size of the gameobject its attatched to over time
            transform.localScale = new Vector2(transform.localScale.x +increaseAmount/1000,transform.localScale.y+increaseAmount/1000);


    }
}
