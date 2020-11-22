using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour
{
    Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + AmmoManager.currentAmmo;
    }
}
