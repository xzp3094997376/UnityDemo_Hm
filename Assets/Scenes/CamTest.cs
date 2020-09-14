using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamTest : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 1, 0);
    Camera cam;
    public GameObject go;
    void Start()
    {
        cam = GetComponent<Camera>();
        go.transform.localScale = Vector3.one * 10;
        EditorUtility.SetDirty(go);
    }

    void LateUpdate2()
    {
        Vector3 camoffset = new Vector3(-offset.x, -offset.y, offset.z);
        Matrix4x4 m = Matrix4x4.TRS(camoffset, Quaternion.identity, new Vector3(1, 1, -1));
        cam.worldToCameraMatrix = m * transform.worldToLocalMatrix;
    }
}
