using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyreButtonsScript : MonoBehaviour
{
    public GameObject exit;
    public GameObject door;
    public GameObject exitWall;
    public GameObject deadMarker;
    public GameObject begMarker;
    public GameObject edgeMarker;
    public GameObject buttons;


    private string noteString; 

    private bool deadDone;
    private bool begDone;
    private bool edgeDone;

    private AudioSource[] sounds; // [ending, dead, beg, edge]

    // Start is called before the first frame update
    void Start()
    {
        noteString = "";
        deadDone = false;
        begDone = false;
        edgeDone = false;
        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deadDone && begDone && edgeDone) {
            StartCoroutine(EndLevel());
        }
    }

    public void AddNote(string note) {
        noteString += note;
    }

    public void ClearNotes() {
        noteString = "";
    }

    public void PlayNotes() {
        if (noteString.Equals("DEAD")) {
            deadDone = true;
            sounds[1].Play();
            deadMarker.SetActive(true);
            // reveal first part of the end
        } else if (noteString.Equals("BEG")) {
            begDone = true;
            sounds[2].Play();
            begMarker.SetActive(true);
            // reveal second part of the end
        } else if (noteString.Equals("EDGE")) {
            edgeDone = true;
            sounds[3].Play();
            edgeMarker.SetActive(true);
            // reveal third part of the end
        }

        noteString = "";
    }

    IEnumerator EndLevel() {
        yield return new WaitForSeconds(5f);
        sounds[0].Play();
        exitWall.SetActive(false);
        exit.SetActive(true);
        buttons.SetActive(false);
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor() {
        yield return new WaitForSeconds(2f);
        door.GetComponent<DoorScript>().OpenDoor();
    }
}
