using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public XRNode inputSource;

    private OVRCameraRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    int currentPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponentInChildren<OVRCameraRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.gameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("checkpoint1") && currentPosition == 0)
        {
            currentPosition += 1;
        }
        else if (other.gameObject.name.Equals("checkpoint2") && currentPosition == 1)
        {
            currentPosition += 1;
        }
        else if (other.gameObject.name.Equals("checkpoint3") && currentPosition == 2)
        {
            currentPosition += 1;
        }
        else if (other.gameObject.name.Equals("checkpoint4") && currentPosition == 3)
        {
            currentPosition += 1;
        }
        else if (other.gameObject.name.Equals("checkpoint5") && currentPosition == 4)
        {
            currentPosition += 1;
        }
        else if (other.gameObject.name.Equals("checkpoint6") && currentPosition == 5)
        {
            currentPosition += 1;
        }
    }
}
