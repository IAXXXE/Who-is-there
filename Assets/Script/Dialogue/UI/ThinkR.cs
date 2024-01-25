using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThinkR : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Player.Instance.stat == PlayerStat.Think)
            EventHandler.CallShowOptionEvent(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(Player.Instance.stat == PlayerStat.Think)
            EventHandler.CallHideOptionEvent(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Player.Instance.stat == PlayerStat.Think)
            EventHandler.CallSelectOptionEvent(false);
    }
}