using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsScript : MonoBehaviour
{
    public static SoundEffectsScript instance;

   [SerializeField] public AudioClip playSound;
   [SerializeField] public AudioClip startSound;
   [SerializeField]private AudioClip jumpSound;
   [SerializeField]private AudioClip jumpDownSound;
   [SerializeField]public AudioClip loseSound;
   [SerializeField]private AudioClip pickUpSound;
   [SerializeField]private AudioClip highscoreSound;
   private AudioSource audioSource;
   private void Awake()
   {
       instance = this;
       audioSource = GetComponent<AudioSource>();
   }

   public void PlaySound()
   {
       audioSource.PlayOneShot(playSound);
       
   }   
   public void StartSound()
   {
       audioSource.PlayOneShot(startSound);
       
   }   
   public void JumpSound()
   {
       audioSource.PlayOneShot(jumpSound);
 }
   public void JumpDownSound()
   {
       audioSource.PlayOneShot(jumpDownSound);
      }
   public void LoseSound()
   {
       audioSource.PlayOneShot(loseSound);
   }
   public void PickUpSound()
   {
       audioSource.PlayOneShot(pickUpSound);
   }
   public void HighScoreSound()
   {
       audioSource.PlayOneShot(highscoreSound);
   }
}
