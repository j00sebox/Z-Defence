using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour, IDropHandler
{
    public SlotManager manager;

    public bool occupied = false;

    public RectTransform pos;

    GameObject item;

    RectTransform itemPos;

    void Start()
    {
        pos = GetComponent<RectTransform> ();
    }

    void Update()
    {
        if (item != null)
        {
            if (!item.GetComponent<DragDrop> ().placed)
            {
                occupied = false;
            }
        }
    }

    public void ChangeItemRef(GameObject ob)
    {
        item = ob;
        itemPos = item.GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData evenData)
    {
        if (evenData.pointerDrag != null && occupied)
        {
            item = evenData.pointerDrag;
            itemPos = item.GetComponent<RectTransform>();
            manager.FindNewSlot(item);
            return;
        }
        else if (evenData.pointerDrag != null && !occupied)
        {
            item = evenData.pointerDrag;
            itemPos = item.GetComponent<RectTransform>();
            itemPos.anchoredPosition = pos.anchoredPosition; 
            occupied = true; 
            item.GetComponent<DragDrop> ().placed = true;
            return;
        }
        
    }
}
