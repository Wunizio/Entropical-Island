using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTape : MonoBehaviour
{
    public AudioClip song;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().AddSong(song);
            Destroy(gameObject);
        }
    }
}
