using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    WeaponSlot[] slots;

    DragDrop[] weapons;

    public Loadout l;

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<WeaponSlot> ();

        weapons = GetComponentsInChildren<DragDrop> ();

        slots[0].item = GetItem();
        slots[0].item.GetComponent<DragDrop> ().placed = true;
        slots[0].occupied = true;
    }
    
    // if slot is occupied this will find a new one for the item
    public void FindNewSlot(GameObject item)
    {
        for(int i = 2; i < slots.Length; i++)
        {
            if(!slots[i].occupied)
            {
                // snap item into the middle of the box
                item.GetComponent<RectTransform>().anchoredPosition = slots[i].pos.anchoredPosition;
                item.GetComponent<DragDrop> ().placed = true;
                slots[i].occupied = true;
                // change the item in the slot
                slots[i].ChangeItemRef(item);
                break; // once the new slot has been found the loop can end
            }

        }
    }
    
    // get the item that is in loadout slot 1
    GameObject GetItem()
    {
        foreach (DragDrop weapon in weapons)
        {
            if(l.loadout[0] == weapon.weaponType)
            {
                return weapon.gameObject;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        // check loadout slot 1
        if (slots[0].occupied)
        {
            l.loadout[0] = slots[0].item.GetComponent<DragDrop> ().weaponType;
        }
        else
        {
            l.loadout[0] = Guns.Weapons.None;
        }

        // check loadout slot 2
        if (slots[1].occupied)
        {
            l.loadout[1] = slots[1].item.GetComponent<DragDrop> ().weaponType;
        }
        else
        {
            l.loadout[1] = Guns.Weapons.None;
        }
    }
}
