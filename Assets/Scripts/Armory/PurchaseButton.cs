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

    // when player navigates back to the armory the ammo count for each weapon will be updated
    void OnEnable()
    {
        ammoText.text = "Ammo: " + AmmoManager.guns[ammoIndex].amount;
    }

    void Purchase()
    {
        // if gun hasn't been purchased
        if (!gunUI.purchased)
        {
            // and player has enough points
            if (PointsManager.points >= gunCost)
            {
                PointsManager.points -= gunCost;
                gunUI.purchased = true;
                pText.text = "Buy Ammo"; // change text on button
                gunCostText.enabled = false;
                costText.enabled = true;
                // after purchase the gun will start with it's max ammo
                AmmoManager.guns[(int)gunUI.type].amount = AmmoManager.guns[(int)gunUI.type].maxAmmo;
                ammoText.text = "Ammo: " + AmmoManager.guns[ammoIndex].amount;
            }
        }
        else // player wants to buy ammo
        {
            if (PointsManager.points >= ammoCost && AmmoManager.guns[ammoIndex].amount <  AmmoManager.guns[ammoIndex].maxAmmo)
            {
                // if the amount of ammo added puts the ammo over the max then it will just be set to the max
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
