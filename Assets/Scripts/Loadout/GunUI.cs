using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    public bool purchased = false;

    public Guns.Weapons type;

    Image gunImage;

    // Start is called before the first frame update
    void Start()
    {
        gunImage = GetComponent<Image> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(purchased)
        {
            gunImage.enabled = true;
        }
        else
        {
            gunImage.enabled = false;
        }
    }
}
