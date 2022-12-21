using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class Cells : MonoBehaviour, IDropHandler
{
    GameObject cell;
    public bool taken = false;
    public ButtonScript currentblock;
    public Cells currentcell;
    private void Update() 
    {
        if (transform.childCount != 1){
            taken = false;
        }
        else 
        {
            taken = true;
        }
    }
    public void OnDrop(PointerEventData d)
    {
        if (d.pointerDrag != null && !taken)
        {
            d.pointerDrag.transform.SetParent(transform);
            d.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            taken = true;
            cell = d.pointerDrag;
        }
        //
    
   
  }

}
