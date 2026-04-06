using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must only be used by Gate tags
public class GateManager : MonoBehaviour
{
    public AudioClip warningSound; // Marimba 3 Notes Descend.wav
    public AudioClip doneSound; // Magic Score 5.wav
    private GearManager gearManager;
    private GameObject gateA;
    private GameObject gateE;
    public bool doneA = false;
    public bool doneE = false;

    // Start is called before the first frame update
    void Start()
    {
        gearManager = GameObject.Find("Canvas").GetComponent<GearManager>();
        gateA = GameObject.Find("Gate-Airgirl");
        gateE = GameObject.Find("Gate-Earthboy");
        doneA = false;
        doneE = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gearManager.collected >= gearManager.total)
        {
            if (gameObject.name == "Gate-Airgirl" && other.gameObject.name == "Airgirl")
            {
                doneA = true;
                AudioSource.PlayClipAtPoint(doneSound, Camera.main.transform.position, 0.5f);
            }
            if (gameObject.name == "Gate-Earthboy" && other.gameObject.name == "Earthboy")
            {
                doneE = true;
                AudioSource.PlayClipAtPoint(doneSound, Camera.main.transform.position, 0.5f);
            }
            if (gameObject.name == "Gate-Airgirl" && other.gameObject.name == "Earthboy" || gameObject.name == "Gate-Earthboy" && other.gameObject.name == "Airgirl")
            {
                GameObject warning = GameObject.Find("Canvas").transform.Find("Warning-WrongGate").gameObject;
                warning.SetActive(true);
                AudioSource.PlayClipAtPoint(warningSound, Camera.main.transform.position, 0.5f);
            }
        }
        else
        {
            GameObject warning = GameObject.Find("Canvas").transform.Find("Warning-GearsLeft").gameObject;
            warning.SetActive(true);
            AudioSource.PlayClipAtPoint(warningSound, Camera.main.transform.position, 0.5f);
        }
    }
}