using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
 
    public void PlayGame()
    {
        //Loads main scene
        StartCoroutine(PlayGameDelay());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         
            
            //PlayGame();
            StartCoroutine(PlayGameDelay());
        }
    }

   IEnumerator PlayGameDelay()
   {
       SoundEffectsScript.instance.PlaySound();
           
        yield return new WaitForSeconds( SoundEffectsScript.instance.playSound.length);
        SceneManager.LoadScene(1);
    }
}
