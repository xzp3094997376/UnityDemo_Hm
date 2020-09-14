using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestRect : MonoBehaviour
{
    public RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
         rt= GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rt.offsetMax+"   "+ rt.offsetMin+"  "+rt.sizeDelta+"  "+rt.rect.size);   //矩形的点位置-锚点的位置

        TestSafeArea();
    }

    /// <summary>
    ///适配刘海屏
    /// </summary>
    void TestSafeArea()
    {        
        Rect _safeArea = Screen.safeArea;
        Debug.Log(_safeArea.size + "  " + _safeArea.max + "  " + _safeArea.min+"   "+_safeArea.height);
#if UNITY_EDITOR

#endif
    }
}
