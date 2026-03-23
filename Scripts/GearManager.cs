using TMPro; // Must be added to the top
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GearManager : MonoBehaviour
{
    public int collected = 0;
    public int total;
    public TMPro.TMP_Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Gear").Length;
        counterText = GameObject.Find("Canvas").transform.Find("GearCounter").gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = $"{collected}/{total}";
    }
}