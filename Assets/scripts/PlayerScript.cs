using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField][Header("Pickup up score amount")]
    private float pickUpScoreIncrease = 67;
    [SerializeField][Header("List of keys used to jump")] private List<KeyCode> jumpKeys;
[SerializeField]private float jumpHeight = 1f;
private bool canJump = false;
  bool downJump=false;
private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SoundEffectsScript.instance.StartSound();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag.Equals("obstacle"))
         {
             StartCoroutine(LevelEnd());
         }
         else if(other.gameObject.tag.Equals("pickup"))
         {
             SoundEffectsScript.instance.PickUpSound();
             Score.Instance.IncreaseScore(pickUpScoreIncrease);
             Destroy(other.gameObject);
         }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("floor"))
        {
            canJump = true;
        }
       
     
    }



    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("floor"))
        {
            canJump = false;
        }
    }
    private void Jump()
    {
        foreach (var jumpKey in jumpKeys)
        {
          
            if (Input.GetKeyDown(jumpKey))
            {
                if (canJump)
                {
                    SoundEffectsScript.instance.JumpSound();
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    downJump = true;
                }
                else if (downJump)
                { 
                    SoundEffectsScript.instance.JumpDownSound();
                    rb.AddForce(Vector2.down * jumpHeight, ForceMode2D.Impulse);
                    downJump = false;
                }
            }
        }
    }
    IEnumerator LevelEnd()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Score.Instance.inPlay = false;
       PlayerPrefs.SetFloat("lastscore",Score.Instance.score);
       SoundEffectsScript.instance.LoseSound();
       yield return new WaitForSeconds(SoundEffectsScript.instance.loseSound.length);
        SceneManager.LoadScene(0);
    }
}
