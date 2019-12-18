using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    Plastic,
    Wood,
    Metal,
    Stone,
    Glass
}

public class ObjectAudioSourceScript : MonoBehaviour
{
    [Range(0f,1f)]
    public float hollowness=0;

    public AudioType audioType;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void OnGUI()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
