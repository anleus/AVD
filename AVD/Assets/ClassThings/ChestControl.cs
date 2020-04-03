using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class ChestControl : MonoBehaviour
{
    void Play()
    {
        GetComponent<PlayableDirector>().Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Play();
        }
    }
}
