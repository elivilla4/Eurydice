using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PaintingScript : MonoBehaviour
{
    private Material paintingMaterial;
    public GameObject videoObject;
    public VideoPlayer videoPlayer;
    public bool introPainting;
    public GameObject door;

    private bool videoPlaying;
    private float videoLength;

    // Start is called before the first frame update
    void Start()
    {
        videoObject.SetActive(false);
        videoPlaying = false;
        videoLength = (float) videoPlayer.clip.length;
    }

    public void ActivatePainting() {
        if (!videoPlaying) {
            videoObject.SetActive(true);
            videoPlayer.Play();
            videoPlaying = true;
            StartCoroutine(StopVideo());
        }
    }

    public void DeactivatePainting() {
        videoPlayer.Stop();
        videoObject.SetActive(false);
        videoPlaying = false;
        if (introPainting) {
            door.GetComponent<DoorScript>().OpenDoor();
        }
    }

    IEnumerator StopVideo() {
        yield return new WaitForSeconds(videoLength);
        DeactivatePainting();
    }
}
