using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{

    private Animator anim;
    private bool stringCut;

    public GameObject bowString;

    // Start is called before the first frame update
    void Start()
    {
        stringCut = false;
        anim = GetComponent<Animator>();
        anim.Play("BowIdle");
        bowString.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Knife") {
            if (!stringCut) {
                stringCut = true;
                bowString.SetActive(true);
                bowString.GetComponent<StringScript>().MoveString();
            }
        }
    }
}
