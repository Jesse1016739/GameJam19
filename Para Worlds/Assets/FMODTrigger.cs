﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODTrigger : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string Event;
    public bool PlayOnAwake;

    // Start is called before the first frame update
    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayOnAwake)
            PlayOneShot();
    }
}
