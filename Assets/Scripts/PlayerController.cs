using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 0.2f;
    StickController stickCont;
    public GameObject stickController;
    public bool mouseDown;

    void Start()
    {
        stickCont = stickController.GetComponent<StickController>();
    }

    void Update()
    {

        Vector3 lookTarget = new Vector3(stickCont.hit.point.x, transform.position.y, stickCont.hit.point.z);
        if (Input.GetKey(KeyCode.Space) && mouseDown == false && stickCont.movePositionEnable == true)
        {
            transform.LookAt(lookTarget);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(stickCont.hit.point.x, transform.position.y, stickCont.hit.point.z), moveSpeed);
        }
        else if (Input.GetKey(KeyCode.R) && mouseDown == false && stickCont.movePositionEnable == true)
        {
            transform.LookAt(lookTarget);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouseDown = true;
        }
        else if ((Input.GetKeyUp(KeyCode.Mouse0)))
        {
            mouseDown = false;
        }
    }
}

