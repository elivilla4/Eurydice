using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PaintingScript : MonoBehaviour
{
    public GameObject videoObject;
    public VideoPlayer videoPlayer;
    public bool introPainting;
    public GameObject door;

    public Material endMaterial;
    private Material[] mats;

    private bool videoPlayed;
    private float videoLength;

    // Start is called before the first frame update
    void Start()
    {
        videoObject.SetActive(false);
        videoPlayed = false;
        videoLength = (float) videoPlayer.clip.length;
        mats = GetComponent<MeshRenderer>().materials;
    }

    public void ActivatePainting() {
        if (!videoPlayed) {
            videoObject.SetActive(true);
            videoPlayer.Play();
            videoPlayed = true;
            StartCoroutine(StopVideo());
        }
    }

    public void DeactivatePainting() {
        videoPlayer.Stop();
        videoObject.SetActive(false);
        if (introPainting) {
            door.GetComponent<DoorScript>().OpenDoor();
        }
    }

    IEnumerator StopVideo() {
        yield return new WaitForSeconds(videoLength);
        DeactivatePainting();
        mats[1] = endMaterial;
        GetComponent<MeshRenderer>().materials = mats;
    }
}
