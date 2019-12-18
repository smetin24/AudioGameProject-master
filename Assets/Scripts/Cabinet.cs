using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public static Cabinet CabinetInstance;

    public AudioSource audioSource;

    public AudioClip feed;


    void Awake()
    {
        CabinetInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.isPlaying);
        if (audioSource.isPlaying == false)
        {
            EasySurvivalScripts.PlayerMovement.playerMovementInstance.enabled = true;
        }
        if (GameManager.gameManagerInstance.cabinetActive)
        {
            if (audioSource.isPlaying == false)
            {
                EasySurvivalScripts.PlayerMovement.playerMovementInstance.enabled = true;
                GameManager.gameManagerInstance.ActivateWindow();
            }
        }
    }

    void StartFeedingSequence()
    {
        audioSource.PlayOneShot(feed);//insert feeding sound here
        EasySurvivalScripts.PlayerMovement.playerMovementInstance.enabled = false;
        GameManager.gameManagerInstance.cabinetActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StickTop"))
        {
            if (!GameManager.gameManagerInstance.cabinetActive)
            {
                StartFeedingSequence();
            }
        }
    }
}
