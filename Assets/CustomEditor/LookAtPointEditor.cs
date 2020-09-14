using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LookAtPoint))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    SerializedProperty lookAtPoint;

    void OnEnable()
    {
        lookAtPoint = serializedObject.FindProperty("lookAtPoint");
        Debug.Log("LookAtPointEditor::Enable"); 
    }

    /// <summary>
    /// 检视口面板中去调试 
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(lookAtPoint);//对inspect中的视图变化监视
        serializedObject.ApplyModifiedProperties();
        //Debug.Log("OnGUI");
        if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y)
        {
            EditorGUILayout.LabelField("(Above this object)");
        }
        if (lookAtPoint.vector3Value.y < (target as LookAtPoint).transform.position.y)
        {
            EditorGUILayout.LabelField("(Below this object)");
        }
        EditorGUILayout.LabelField(lookAtPoint.vector3Value.ToString());
    }


    /// <summary>
    ///在场景中测试一个就合适的位置，不用再去运行调试
    /// </summary>
    public void OnSceneGUI()
    {
        var t = (target as LookAtPoint);

        EditorGUI.BeginChangeCheck();
        Vector3 pos = Handles.PositionHandle(t.lookAtPoint, Quaternion.identity);//对pos　在场景ｓｃｅｎｅ变化监视
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Move point");
            t.lookAtPoint = pos;
            t.Update();
            //Debug.Log(t.lookAtPoint);
            //t.InspectTest();
        }
    }
}