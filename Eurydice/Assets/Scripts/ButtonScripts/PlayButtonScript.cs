using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    private GameObject buttonParent;
    private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        buttonParent = transform.parent.gameObject;
        buttonSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            buttonParent.GetComponent<LyreButtonsScript>().PlayNotes();
            buttonSound.Play();
        }
    }
}
