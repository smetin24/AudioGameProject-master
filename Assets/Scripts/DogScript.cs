using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Transform dogDestination;
    public float dogWalkTime;
    public AudioSource audioSource;
    public AudioClip cry;
    public AudioClip walk;
    bool startSound;
    bool checkPlayed = false;
    bool checkSecondPlayed = false;
    Vector3 firstPos;


    private void Start()
    {
        firstPos = transform.position;
        audioSource.PlayOneShot(walk);
    }

    void Update()
    {
        Debug.Log(firstPos);
        if(!checkPlayed)
        transform.position = Vector3.MoveTowards(transform.position, dogDestination.position, dogWalkTime / 50);
        if (transform.position == dogDestination.position && !checkPlayed)
        {
            audioSource.Stop();
            audioSource.clip = walk;
            startSound = true;
        }
        if (startSound)
        {
            DogHungerSound();
        }

        if (GameManager.gameManagerInstance.dogSecSequence)
        {
            transform.position = Vector3.MoveTowards(transform.position, firstPos, dogWalkTime / 50);

            if (!checkSecondPlayed)
            {
                MoveToDoor();
            }
            if (transform.position == firstPos)
            {
                GameManager.gameManagerInstance.DoorActive=true;
                audioSource.Stop();
            }
        }
    }

    void DogHungerSound()
    {
        Debug.Log("Dog Section Finished!!! " + "Insert paw and cry sound here");//Dog cry sound
        audioSource.PlayOneShot(cry);
        startSound = false;
        checkPlayed = true;
    }

    void MoveToDoor()
    {
        audioSource.PlayOneShot(walk);
        checkSecondPlayed = true;
    }
}
