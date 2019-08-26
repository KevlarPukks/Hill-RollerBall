using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchIncrease : MonoBehaviour
{
    [SerializeField] private float increaseAmount = 0.01f;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Score.Instance.inPlay)
        {
            audioSource.Stop();
        }
        if (audioSource.pitch < 1.3)
            audioSource.pitch += increaseAmount*Time.deltaTime;
    }
}
