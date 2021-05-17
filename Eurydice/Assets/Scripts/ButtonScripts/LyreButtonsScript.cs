using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyreButtonsScript : MonoBehaviour
{
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
            sounds[0].Play();
        }
    }

    public void AddNote(string note) {
        noteString += note;
    }

    public void ClearNotes() {
        noteString = "";
    }

    public void PlayNotes() {
        if (noteString == "DEAD") {
            deadDone = true;
            sounds[1].Play();
            // reveal first part of the end
        } else if (noteString == "BEG") {
            begDone = true;
            sounds[2].Play();
            // reveal second part of the end
        } else if (noteString == "EDGE") {
            edgeDone = true;
            sounds[3].Play();
            // reveal third part of the end
        }

        noteString = "";
    }
}
