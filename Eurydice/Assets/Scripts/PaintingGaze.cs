using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingGaze : MonoBehaviour
{
    //public Image imgGaze;

    public float totalTime = 2;
    bool lookingAtPainting;
    float lookTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lookingAtPainting)
        {
            lookTimer += Time.deltaTime;
            //imgGaze.fillAmount = lookTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay)) // raycast collides with an object
        {
            if (_hit.transform.CompareTag("Painting")) // collision is with a painting
            {
                lookingAtPainting = true;

                if(lookTimer >= totalTime)
                    {
                        _hit.transform.gameObject.GetComponent<PaintingScript>().ActivatePainting();
                    }
            }
        } else {
            lookingAtPainting = false;
        }
    }

    // public void GVROn()
    // {
    //     lookingAtPainting = true;
    //     Debug.Log("On");

    // }

    // public void GVRoff()
    // {
    //     lookingAtPainting = false;
    //     lookTimer = 0;
    //     imgGaze.fillAmount = 0;
    //     Debug.Log("Off");

    // }
}