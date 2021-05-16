using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrpheusMovement : MonoBehaviour
{
    public List<GameObject> locations = new List<GameObject>();
    int currentLocation;

    // Start is called before the first frame update
    void Start()
    {
        currentLocation = 0;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
     
    }
}
