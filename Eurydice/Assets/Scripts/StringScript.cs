using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringScript : MonoBehaviour
{

    private Animator anim;
    private bool onBow;

    public GameObject lyreStrings;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        onBow = true;
        anim = GetComponent<Animator>();
        anim.Play("StringIdle");
        lyreStrings.SetActive(false);
        gameObject.SetActive(false);
        buttons.SetActive(false);
    }

    public void MoveString() {
        if (onBow) {
            onBow = false;
            gameObject.SetActive(true);
            anim.Play("String");
        }
    }

    public void EndString() {
        gameObject.SetActive(false);
        lyreStrings.SetActive(true);
        buttons.SetActive(true);
    }
}
