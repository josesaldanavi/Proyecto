using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_soundActive : MonoBehaviour {

    public void Event_ActivarSound()
    {
        GetComponent<AudioSource>().Play();
    }

}
