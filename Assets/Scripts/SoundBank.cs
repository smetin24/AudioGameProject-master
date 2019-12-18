using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public static SoundBank SoundBankInstance;

    public bool cabinetActive;

    bool isCabinetActive=false;
    // Start is called before the first frame update
    void Awake()
    {
        SoundBankInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActivateCabinet()
    {
        if (!isCabinetActive)
        {
            Debug.Log("Cabinet Activated!!!  --"+" --Insert feeding sound here!");

            isCabinetActive = true;
        }
    }
}
