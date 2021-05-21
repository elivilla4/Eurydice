using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public XRNode inputSource;
    public GameObject orpheus;

    private OVRCameraRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    int currentPosition = 0;

    // Orpheus checkpoints
    Vector3 orphCkpt1 = new Vector3(2.3f, 2.3f, -24);
    Vector3 orphCkpt2 = new Vector3(-6f, 2.3f, -24);
    Vector3 orphCkpt3 = new Vector3(-6f, 2.3f, -32);
    Vector3 orphCkpt4 = new Vector3(2.3f, 2.3f, -32);
    Vector3 orphCkpt5 = new Vector3(-3.3f, 2.3f, -20);

    float orpheusSpeed = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponentInChildren<OVRCameraRig>();
        orpheus.gameObject.transform.position = new Vector3(2.3f, 2.3f, -16);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        Quaternion headYaw = Quaternion.Euler(0, rig.gameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * Time.deltaTime * speed);
        if (currentPosition == 1 && Vector3.Distance(orpheus.transform.position, orphCkpt1) > 0.001f)
        {
            orpheus.transform.position = Vector3.MoveTowards(orpheus.transform.position, orphCkpt1, orpheusSpeed * Time.deltaTime);
        } 
        else if (currentPosition == 2 && Vector3.Distance(orpheus.transform.position, orphCkpt2) > 0.001f)
        {
            orpheus.transform.position = Vector3.MoveTowards(orpheus.transform.position, orphCkpt2, orpheusSpeed * Time.deltaTime);
        }
        else if (currentPosition == 3 && Vector3.Distance(orpheus.transform.position, orphCkpt3) > 0.001f)
        {
            orpheus.transform.position = Vector3.MoveTowards(orpheus.transform.position, orphCkpt3, orpheusSpeed * Time.deltaTime);
        }
        else if (currentPosition == 4 && Vector3.Distance(orpheus.transform.position, orphCkpt4) > 0.001f)
        {
            orpheus.transform.position = Vector3.MoveTowards(orpheus.transform.position, orphCkpt4, orpheusSpeed * Time.deltaTime);
        }
        else if (currentPosition == 5 && Vector3.Distance(orpheus.transform.position, orphCkpt5) > 0.001f)
        {
            orpheus.transform.position = Vector3.MoveTowards(orpheus.transform.position, orphCkpt5, orpheusSpeed * Time.deltaTime);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("checkpoint1") && currentPosition == 0)
        {
            print("checkpoint 1");
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
