using UnityEditor.Presets;

// PresetSelector 接收器用所选值更新 EditorWindow。

public class MySettingsReceiver : PresetSelectorReceiver
{
    Preset initialValues;
    MyWindowSettings currentSettings;
    MyEditorWindow currentWindow;

    public void Init(MyWindowSettings settings, MyEditorWindow window)
    {
        currentWindow = window;
        currentSettings = settings;
        initialValues = new Preset(currentSettings);
    }

    public override void OnSelectionChanged(Preset selection)
    {
        if (selection != null)
        {
            //将选择应用于临时设置
            selection.ApplyTo(currentSettings);
        }
        else
        {
            // 未进行任何选择。将初始值反向应用于临时选择。
            initialValues.ApplyTo(currentSettings);
        }

        //将新的临时设置应用于我们的管理器实例
        currentSettings.ApplySettings(currentWindow);
    }

    public override void OnSelectionClosed(Preset selection)
    {
        // 最后一次调用选择更改以确保您具有最后的选择值。
        OnSelectionChanged(selection);
        //在此处销毁接收器，所以您不需要保留其引用。
        DestroyImmediate(this);
    }
}