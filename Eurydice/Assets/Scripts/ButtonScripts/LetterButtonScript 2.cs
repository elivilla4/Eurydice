using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButtonScript : MonoBehaviour
{
    public string note;
    private GameObject buttonParent;
    private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        buttonParent = transform.parent.gameObject;
        buttonSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            buttonParent.GetComponent<LyreButtonsScript>().AddNote(note);
            buttonSound.Play();
        }
    }
}
