using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{

    private Animator anim;

    public GameObject bowString;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("BowIdle");
        bowString.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Knife") {
            bowString.SetActive(true);
            bowString.GetComponent<StringScript>().MoveString();
        }
    }
}
