using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PaintingScript : MonoBehaviour
{
    private Material paintingMaterial;
    public GameObject videoObject;
    public VideoPlayer videoPlayer;
    private float videoLength;

    // Start is called before the first frame update
    void Start()
    {
        videoObject.SetActive(false);
        videoLength = (float) videoPlayer.clip.length;
    }

    public void ActivatePainting() {
        videoObject.SetActive(true);
        videoPlayer.Play();
    }

    public void DeactivatePainting() {
        videoPlayer.Stop();
        videoObject.SetActive(false);
    }

    IEnumerator StopVideo() {
        yield return new WaitForSeconds(videoLength);
        DeactivatePainting();
    }
}
