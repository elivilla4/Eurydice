using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("BowIdle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
