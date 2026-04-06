using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must only be used by Gear prefabs
public class Gear : MonoBehaviour
{
    public AudioClip collectedSound; // Bell Star 2.wav
    public float speed = 2f;
    public float height = 0.25f;
    public bool randomizeStart = true; // Prevents all gears from moving in sync
    private GearManager gearManager;

    private Vector3 startPos;
    private float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        gearManager = GameObject.Find("Canvas").GetComponent<GearManager>();
        startPos = transform.position;
        if (randomizeStart)
        {
            timeOffset = Random.Range(0f, 10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Hovering animation
        float newY = startPos.y + Mathf.Sin((Time.time + timeOffset) * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    // Add 1 to gear counter and destroy gear
    private void Collect()
    {
        AudioSource.PlayClipAtPoint(collectedSound, Camera.main.transform.position, 0.5f);
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