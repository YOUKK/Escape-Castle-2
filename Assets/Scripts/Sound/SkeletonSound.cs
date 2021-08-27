using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSound : MonoBehaviour
{
    public AudioClip WalkSound;
    private AudioSource theAudioSource;

    private float walkTimer;
    private float walkWaitingTime;

    void Start()
    {
        theAudioSource = GetComponent<AudioSource>();

        walkTimer = 0f;
        walkWaitingTime = 0.3f;
    }

    void Update()
    {
        walkTimer += Time.deltaTime;
        if (walkTimer > walkWaitingTime)
        {
            WalkSoundPlayer();
            walkTimer = 0;
        }
    }

    private void WalkSoundPlayer()
	{
        theAudioSource.clip = WalkSound;
        theAudioSource.Play();
	}
}
