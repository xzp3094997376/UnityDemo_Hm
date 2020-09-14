using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;

public class MyEditorWindow : EditorWindow

{
    // 获取预设图标和样式来进行显示
    private static class Styles
    {
        public static GUIContent presetIcon = EditorGUIUtility.IconContent("Preset.Context");
        public static GUIStyle iconButton = new GUIStyle("IconButton");

    }

    Editor m_SettingsEditor;
    MyWindowSettings m_SerializedSettings;

    public string someSettings
    {
        get { return EditorPrefs.GetString("MyEditorWindow_SomeSettings"); }
        set { EditorPrefs.SetString("MyEditorWindow_SomeSettings", value); }
    }

    // 打开窗口的方法
    [MenuItem("Window/MyEditorWindow")]
    static void OpenWindow()
    {
        GetWindow<MyEditorWindow>();
    }

    void OnEnable()
    {
        // 立即创建您的设置及其关联的 Inspector，
        // 用于为窗口和预设中的设置仅创建一个自定义 Inspector。
        m_SerializedSettings = ScriptableObject.CreateInstance<MyWindowSettings>();
        m_SerializedSettings.Init(this);
        m_SettingsEditor = Editor.CreateEditor(m_SerializedSettings);
    }

    void OnDisable()
    {
        Object.DestroyImmediate(m_SerializedSettings);
        Object.DestroyImmediate(m_SettingsEditor);
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("My custom settings", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        // 在"MyManager Settings"行的末尾创建 Preset 按钮。
        var buttonPosition = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight, Styles.iconButton);

        if (EditorGUI.DropdownButton(buttonPosition, Styles.presetIcon, FocusType.Passive, Styles.iconButton))
        {
            //创建接收器实例。当窗口出现时，此接收器会自行毁坏，所以您不需要保留其引用。
            var presetReceiver = ScriptableObject.CreateInstance<MySettingsReceiver>();
            presetReceiver.Init(m_SerializedSettings, this);
            //显示 PresetSelector 模态窗口。presetReceiver 会更新您的数据。
            PresetSelector.ShowSelector(m_SerializedSettings, null, true, presetReceiver);
        }
        EditorGUILayout.EndHorizontal();

        //绘制设置默认 Inspector 并捕获对其所做的任何更改。
        EditorGUI.BeginChangeCheck();
        m_SettingsEditor.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
        {
            //将设置编辑器中所做的更改应用于我们的实例。
            m_SerializedSettings.ApplySettings(this);
        }
    }
}
