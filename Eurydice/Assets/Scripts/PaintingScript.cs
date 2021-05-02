using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    private Material paintingMaterial;

    // Start is called before the first frame update
    void Start()
    {
        paintingMaterial = GetComponent<Renderer>().material;
        paintingMaterial.color = Color.red;
    }

    public void ActivatePainting() {
        paintingMaterial.color = Color.green;
    }
}
