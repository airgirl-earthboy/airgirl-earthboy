using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public int collected = 0;
    public int total;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Gear").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == total)
        {
            GameObject.Find("Canvas").transform.Find("Success").gameObject.SetActive(true);
        }
    }
}