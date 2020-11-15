using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public SlotManager manager;

    [SerializeField] Canvas canvas;

    CanvasGroup canvasGroup;

    RectTransform rect;

    public Guns.Weapons weaponType;

    public bool placed = false;

    void Awake()
    {
        rect = GetComponent<RectTransform> ();
        canvasGroup = GetComponent<CanvasGroup> ();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        placed = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!placed)
        {
            manager.FindNewSlot(gameObject);
        }
    }
    public void OnPointerDown(PointerEventData evenData)
    {
        
    }

    public void OnDrop(PointerEventData evenData)
    {

    }
}
