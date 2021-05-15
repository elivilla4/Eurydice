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

    public int distanceOfRay;
    public LayerMask paintingLayer;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        lookTimer = 0;
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

        if(Physics.Raycast(ray, out _hit, distanceOfRay, paintingLayer)) // raycast collides with an object
        {
            if (_hit.transform.CompareTag("Painting")) // collision is with a painting
            {
                lookingAtPainting = true;

                if(lookTimer >= totalTime)
                    {
                        _hit.transform.gameObject.GetComponent<PaintingScript>().ActivatePainting();
                        lookTimer = 0; 
                    }
            }
        } else {
            lookingAtPainting = false;
        }
    }

}
