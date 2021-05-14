using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject pivot;
    public float openDuration;

    private float endTime;

    private bool opening;
    private bool closing;
    private bool open;


    // Start is called before the first frame update
    void Start()
    {
        opening = false;
        open = false;
        closing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening) {
            if (Time.time < endTime) {
                transform.RotateAround(pivot.transform.position, Vector3.down, 90/openDuration * Time.deltaTime);
            } else {
                opening = false;
                open = true;
            }
        }
    }

    public void OpenDoor() {
        if (!open && !opening) {
            opening = true; 
            endTime = Time.time + openDuration;
        }
    }


}
