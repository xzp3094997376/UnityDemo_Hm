using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestEvent : EventTrigger
{
    protected const int kNoEventMaskSet = -1;
    [SerializeField]
    public LayerMask m_BlockingMask = kNoEventMaskSet;
    // Start is called before the first frame update
    void Start()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.LogError(_ray.direction);
    }

    void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.LogError(_ray.direction);
            Debug.DrawLine(_ray.origin, _ray.GetPoint(100), Color.red, 100);          
        }
    }
    // Update is called once per frame
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        Debug.Log(eventData.pointerCurrentRaycast.gameObject);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        Debug.Log(eventData.selectedObject?.name + "  ____   " + eventData.pointerCurrentRaycast.gameObject);
    }
}
