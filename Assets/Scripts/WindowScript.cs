using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public static WindowScript windowScriptInstance;

    public AudioSource audioSource;
    public AudioClip closing;
    void Awake()
    {
        windowScriptInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.minDistance <= 35)
        {
            audioSource.minDistance += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StickTop"))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(closing);//insert window closing sound here
            GameManager.gameManagerInstance.phoneActive=true;
            
        }
    }
}
