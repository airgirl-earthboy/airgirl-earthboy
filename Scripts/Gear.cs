using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must only be used by Gear prefabs
public class Gear : MonoBehaviour
{
    public AudioClip collectedSound; // Bell Star 2.wav
    private AudioSource audioSource;
    private GearManager gearManager;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
        }
        else
        {
            Debug.Log("AudioSource is NOT null");
        }
        gearManager = GameObject.Find("Grid").GetComponent<GearManager>();
    }

    // Add 1 to gear counter and destroy gear
    private void Collect()
    {
        Debug.Log("Gear collected");
        Debug.Log($"Audio source null: {audioSource != null}\nAudio source playing: {audioSource.isPlaying}");
        if (audioSource != null && !audioSource.isPlaying)
        {
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
        }
        gearManager.collected += 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Could also compare names of GameObjects:
        // (other.name == "Airgirl" || other.name == "Earthboy)
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}