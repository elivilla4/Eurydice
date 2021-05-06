using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PaintingScript : MonoBehaviour
{
    private Material paintingMaterial;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //paintingMaterial = GetComponent<Renderer>().material;
        //paintingMaterial.color = Color.red;
    }

    public void ActivatePainting() {
        //paintingMaterial.color = Color.green;
        videoPlayer.Play();
    }

    public void DeactivatePainting() {
        //paintingMaterial.color = Color.red;
    }
}
