using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public static DoorScript doorScriptInstance;
    public AudioSource audioSource;
    void Awake()
    {
        doorScriptInstance = this;
    }
    private void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
