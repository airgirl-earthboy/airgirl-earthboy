using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollector : MonoBehaviour
{
    public GearManager gearManager;

    // Start is called before the first frame update
    void Start()
    {
        gearManager = GameObject.Find("Grid").GetComponent<GearManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Airgirl" || other.name == "Earthboy")
        {
            Collect();
        }
    }

    private void Collect()
    {
        Debug.Log("Gear collected");
        gearManager.collected += 1;
        Destroy(gameObject);
    }
}