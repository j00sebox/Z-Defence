using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{

    Button purchase;

    Text pText;

    public GunUI gunUI;

    public int gunCost;

    public int ammoCost;

    public int ammoPerBuy;

    bool isPurchased = false;

    public int ammoIndex;

    // Start is called before the first frame update
    void Start()
    {
        purchase = GetComponent<Button>();
        pText = purchase.GetComponentInChildren<Text> ();

        purchase.onClick.AddListener(Purchase);    
    }

    void Purchase()
    {
        if (!gunUI.purchased)
        {
            if (PointsManager.points >= gunCost)
            {
                PointsManager.points -= gunCost;
                isPurchased = true;
                gunUI.purchased = true;
                pText.text = "Buy Ammo";
            }
        }
        else
        {
            if (PointsManager.points >= ammoCost)
            {
                AmmoManager.guns[ammoIndex] += ammoPerBuy;
            }
        }
    }
}
