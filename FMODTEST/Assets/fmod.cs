using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmod : MonoBehaviour
{
    FMOD.Studio.EventInstance AMB;
    // Start is called before the first frame update
    void Start()
    {
        AMB = FMODUnity.RuntimeManager.CreateInstance(""); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
