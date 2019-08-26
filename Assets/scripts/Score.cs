using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    private Text scoreText;
    public float score = 0;
   [SerializeField] private bool isMainMenu =false;
    [SerializeField] private Text highScoreText;
    public bool inPlay;
     private float highScore=0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        scoreText = GetComponent<Text>();
        if (isMainMenu)
        {
            if (PlayerPrefs.HasKey("lastscore"))
            {
                scoreText.text = $"Score:\n {PlayerPrefs.GetFloat("lastscore"):F0}";
                if (PlayerPrefs.HasKey("highscore"))
                {
                    if (PlayerPrefs.GetFloat("highscore")< PlayerPrefs.GetFloat("lastscore"))
                    {
                        SoundEffectsScript.instance.HighScoreSound();
                        highScoreText.text = $"Highscore:\n {PlayerPrefs.GetFloat("lastscore"):F0}";
                        PlayerPrefs.SetFloat("highscore",PlayerPrefs.GetFloat("lastscore"));
                    }
                    else
                    {
                      
                        highScoreText.text =  $"Highscore:\n {PlayerPrefs.GetFloat("highscore"):F0}";
                    }
                }
                else
                {  
                    SoundEffectsScript.instance.HighScoreSound();
                    highScoreText.text = $"Highscore:\n {PlayerPrefs.GetFloat("lastscore"):F0}";
                    PlayerPrefs.SetFloat("highscore",PlayerPrefs.GetFloat("lastscore"));
                }
            }
            else
            {
                scoreText.text = string.Empty;
                highScoreText.text = string.Empty;
            }
        }
        else
        {
            inPlay = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMainMenu) return;
        if (!inPlay) return;
        score += 12 * Time.deltaTime;
        scoreText.text = $"Score:\n {score:F0}";
    }

    public void IncreaseScore(float amount)
    {
        score += amount;
        scoreText.text = $"Score:\n {score:F0}";
    }
}
