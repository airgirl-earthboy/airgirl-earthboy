using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must only be used by Gate tags
public class GateManager : MonoBehaviour
{
    private GearManager gearManager;
    private GameObject gateA;
    private GameObject gateE;
    public bool doneA = false;
    public bool doneE = false;

    // Start is called before the first frame update
    void Start()
    {
        gearManager = GameObject.Find("Grid").GetComponent<GearManager>();
        gateA = GameObject.Find("Gate-Airgirl");
        gateE = GameObject.Find("Gate-Earthboy");
        doneA = false;
        doneE = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "Gate-Airgirl" && other.gameObject.name == "Airgirl")
        {
            if (gearManager.collected == gearManager.total)
            {
                doneA = true;
                Debug.Log("Airgirl has reached gate");
            }
        }
        if (gameObject.name == "Gate-Earthboy" && other.gameObject.name == "Earthboy")
        {
            if (gearManager.collected == gearManager.total)
            {
                doneE = true;
                Debug.Log("Earthboy has reached gate");
            }
        }
    }
}