using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButtonScript : MonoBehaviour
{
    public string note;
    private GameObject buttonParent;
    private AudioSource buttonSound;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        buttonParent = transform.parent.gameObject;
        buttonSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && !pressed) {
            buttonParent.GetComponent<LyreButtonsScript>().AddNote(note);
            buttonSound.Play();
            pressed = true;
            StartCoroutine(Locked());
        }
    }

    IEnumerator Locked() {
        yield return new WaitForSeconds(2f);
        pressed = false;
    }
}
