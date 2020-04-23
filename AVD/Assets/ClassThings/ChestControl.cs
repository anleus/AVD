using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using CreatorKitCodeInternal;

public class ChestControl : MonoBehaviour
{
    private bool opened = false;

    void Play()
    {
        GetComponent<PlayableDirector>().Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            Debug.Log("colision");
            StartCoroutine(MovementManagement(other.gameObject));
            Play();
        }
    }

    IEnumerator MovementManagement(GameObject player) 
    {
        opened = true;
        CharacterControl control = player.GetComponent<CharacterControl>();

        yield return new WaitForSeconds(0.5f);

        control.enabled = false;

        yield return new WaitForSeconds(12f);

        control.enabled = true;

        yield return null;
    }
}
