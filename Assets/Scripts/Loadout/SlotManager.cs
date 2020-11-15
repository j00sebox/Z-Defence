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

        // slots[0].item = GetItem(0);
        // slots[0].item.GetComponent<DragDrop> ().placed = true;
        // slots[0].occupied = true;

        // slots[1].item = GetItem(1);
        // slots[1].item.GetComponent<DragDrop> ().placed = true;
        // slots[1].occupied = true;
    }

    public void FindNewSlot(GameObject item)
    {
        for(int i = 2; i < slots.Length; i++)
        {
            if(!slots[i].occupied)
            {
                item.GetComponent<RectTransform>().anchoredPosition = slots[i].pos.anchoredPosition;
                item.GetComponent<DragDrop> ().placed = true;
                slots[i].occupied = true;
                slots[i].ChangeItemRef(item);
                break;
            }

        }
    }
    
    GameObject GetItem(int index)
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
        if (slots[0].occupied)
        {
            l.loadout[0] = slots[0].item.GetComponent<DragDrop> ().weaponType;
        }
        else
        {
            l.loadout[0] = Guns.Weapons.None;
        }

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
