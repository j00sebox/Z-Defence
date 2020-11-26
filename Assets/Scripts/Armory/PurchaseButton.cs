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

    public Text ammoText;

    public Text costText;

    public Text gunCostText;

    // Start is called before the first frame update
    void Awake()
    {
        purchase = GetComponent<Button>();
        pText = purchase.GetComponentInChildren<Text> ();

        purchase.onClick.AddListener(Purchase);    
    }

    void OnEnable()
    {
        ammoText.text = "Ammo: " + AmmoManager.guns[ammoIndex].amount;
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
                gunCostText.enabled = false;
                costText.enabled = true;
                AmmoManager.guns[(int)gunUI.type].amount = AmmoManager.guns[(int)gunUI.type].maxAmmo;
                ammoText.text = "Ammo: " + AmmoManager.guns[ammoIndex].amount;
            }
        }
        else
        {
            if (PointsManager.points >= ammoCost && AmmoManager.guns[ammoIndex].amount <  AmmoManager.guns[ammoIndex].maxAmmo)
            {
                if( (AmmoManager.guns[ammoIndex].amount + ammoPerBuy) > AmmoManager.guns[ammoIndex].maxAmmo)
                {
                    AmmoManager.guns[ammoIndex].amount = AmmoManager.guns[ammoIndex].maxAmmo;
                }
                else
                {
                    AmmoManager.guns[ammoIndex].amount += ammoPerBuy;
                }

                ammoText.text = "Ammo: " + AmmoManager.guns[ammoIndex].amount;
                PointsManager.points -= ammoCost;
                
            }
        }
    }
}
