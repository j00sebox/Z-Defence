using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{

    Button purchase;

    Text pText;

    public GunUI gunUI;

    bool isPurchased = false;

    // Start is called before the first frame update
    void Start()
    {
        purchase = GetComponent<Button>();
        pText = purchase.GetComponentInChildren<Text> ();

        purchase.onClick.AddListener(Purchase);    
    }

    void Purchase()
    {
        if (!isPurchased)
        {
            isPurchased = true;
            gunUI.purchased = true;
            pText.text = "Buy Ammo";
        }
    }
}
