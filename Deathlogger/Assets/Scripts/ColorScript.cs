using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour {

    public Material selectMat;
    bool emmision;
    // Use this for initialization
    void Start () {
        selectMat.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update() {
        if (emmision)
        {
            selectMat.EnableKeyword("_EMISSION");
        }
        else
        {
            selectMat.DisableKeyword("_EMISSION");
        }
        emmision = !emmision;


    }
}
