using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public float dogAnimationStartTimer;
    public float PhoneWaitTimer;
    public GameObject Dog ;
    public GameObject window;
    public GameObject table;

    public bool cabinetActive;
    public bool windowActive;
    public bool dogSecSequence;
    public bool DoorActive;
    public bool TableActive;
    public bool phoneActive;

    float dogTimer=0;
    float phoneTimer=0;


    void Start()
    {
        gameManagerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        dogTimer += 0.02f;

        if (dogTimer >= dogAnimationStartTimer)
        {
            Debug.Log("Dog Section Started!  "+" Insert dog walk sound here");//Dog Walk Sound
            Dog.SetActive(true);
        }
        if (phoneActive)
        {
            ActivatePhone();
        }
        if (DoorActive)
        {
            ActivateDoor();
        }
    }

    public void ActivateWindow()
    {
        WindowScript.windowScriptInstance.enabled = true;
    }

    public void ActivatePhone()
    {
        Debug.Log("method activated");
        phoneTimer += 0.02f;
        if (phoneTimer >= PhoneWaitTimer)
        {
            PhoneScript.phoneScriptInstance.enabled = true;
        }
    }

    public void ActivateDoor()
    {
        DoorScript.doorScriptInstance.enabled = true;
    }
}
