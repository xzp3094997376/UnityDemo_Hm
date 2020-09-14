using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TestAuto : MonoBehaviour
{
    CanvasScaler m_canvasScaler;
    // Use this for initialization
    void Awake()
    {
        m_canvasScaler = this.gameObject.GetComponent<CanvasScaler>();
        if (m_canvasScaler == null)
            //  Log.Instance.Output(Log.Level.ERROR, "AutoCanvas.Awake", "没有找到CanvasScaler，AutoCanvas脚本必须挂在画布下。");
            Debug.Log("auto");
        AutoUI();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        AutoUI();
#endif
    }

    /// <summary>
    /// UI比例适应
    /// </summary>
    private void AutoUI()//元素缩放不在跟随画布缩放比例
    {
        if (m_canvasScaler != null)
        {
            float wScale = Screen.width / 750.0f;
            float hScale = Screen.height / 1334.0f;
            if (hScale < wScale)
                m_canvasScaler.scaleFactor = hScale;
            else
                m_canvasScaler.scaleFactor = wScale;
        }
    }
}
