using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public static PhoneScript phoneScriptInstance;

    public AudioSource audioSource;
    public AudioClip phoneRing;
    void Awake()
    {
        phoneScriptInstance = this;
    }

    private void Start()
    {
        audioSource.PlayOneShot(phoneRing);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.gameManagerInstance.phoneActive)
        {
            if (other.gameObject.CompareTag("StickTop"))
            {
                GameManager.gameManagerInstance.dogSecSequence = true;
            }
        }
    }
}
