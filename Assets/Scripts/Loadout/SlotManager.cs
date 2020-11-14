using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    WeaponSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<WeaponSlot> ();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
