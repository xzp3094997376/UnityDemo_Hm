 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScroll : MonoBehaviour
{
    public ScrollRect sr;
    public float scrollValue;
    public int index = 0;
    public RectTransform rt;
    // Start is called before the first frame update
    void Start()    
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {        
            sr.verticalNormalizedPosition = scrollValue;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine(ray.origin, ray.direction * 1000 + ray.origin, Color.red, 1);
           if(RectTransformUtility.RectangleContainsScreenPoint(rt,Input.mousePosition,Camera.main))
            {
                Debug.DrawLine(ray.origin, ray.direction * 1000 + ray.origin, Color.green, 1);
                Vector3 pos= Camera.main.WorldToScreenPoint(rt.position);
                Debug.Log(pos);
            }
        }                
    }
}
