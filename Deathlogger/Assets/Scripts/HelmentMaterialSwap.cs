using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmentMaterialSwap : MonoBehaviour {
    float Timer = 0;
    public Material[] helmMaterials;
    private int arrayPos = 0;
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if(Timer > .2f)
        {
            Timer = 0;
            arrayPos++;
            GetComponent<MeshRenderer>().material = helmMaterials[arrayPos%helmMaterials.Length];            
        }
    }
}
