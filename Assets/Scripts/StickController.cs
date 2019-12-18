using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    StickSoundController stickCont;

    public GameObject stick;
    public RaycastHit hit;
    public bool movePositionEnable;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    float fixedRotation = 0f;

    float h, v;
    Quaternion originalPos;

    private void Start()
    {
        stickCont = stick.GetComponent<StickSoundController>();
    }
    void Update()
    {
        Debug.Log("hit loc" + hit.point);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            h = horizontalSpeed * Input.GetAxis("Mouse X");
            v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(-v, h, 0);

            if (stickCont.groundCheck == true)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    movePositionEnable = true;
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                }
            }
            else
                movePositionEnable = false;
        }
        else
        {
            transform.localRotation =Quaternion.EulerAngles(-50,0,0);
        }
    }
}
