using UnityEngine;

// 预设系统使用的临时 ScriptableObject

public class MyWindowSettings : ScriptableObject
{
    [SerializeField]
    string m_mSomeSettings;

    public void Init(MyEditorWindow window)
    {
        m_mSomeSettings = window.someSettings;
        Debug.Log("   " + m_mSomeSettings);
    }

    public void ApplySettings(MyEditorWindow window)
    {
        window.someSettings = m_mSomeSettings;
        window.Repaint();
    }
}