using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSoundController : MonoBehaviour
{
    public AudioClip check;
    public AudioClip leave;
    public AudioClip carpet;
    public bool groundCheck;


    AudioSource AudioSource;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objects" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Cabinet" || other.gameObject.tag == "Window" || other.gameObject.tag == "Table")
        {
            AudioSource.PlayOneShot(check);
            Debug.Log("Object type: " + other.GetComponent<ObjectAudioSourceScript>().audioType + "-----" + "Object hollowness: " + other.GetComponent<ObjectAudioSourceScript>().hollowness);
        }
        if (other.gameObject.tag == "Ground")
        {
            AudioSource.PlayOneShot(leave);
            groundCheck = true;
        }
        if (other.gameObject.tag == "Carpet")
        {
            AudioSource.PlayOneShot(carpet);
            groundCheck = true;
        }


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Objects")
    //    {
    //        AudioSource.PlayOneShot(check);
    //        Debug.Log(collision.GetComponent<ObjectAudioSourceScript>().audioType);
    //        Debug.Log(collision.GetComponent<ObjectAudioSourceScript>().hollowness);
    //    }
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        AudioSource.PlayOneShot(leave);
    //        groundCheck = true;
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log(alreadyPlayed);
    //    if (other.gameObject.tag == "Ground" && alreadyPlayed == false)
    //    {
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            AudioSource.PlayOneShot(drag);
    //            alreadyPlayed = true;
    //        }
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = false;
        }
    }
}
