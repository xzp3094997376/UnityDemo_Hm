using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlcok : MonoBehaviour
{
    protected const int kNoEventMaskSet = 1;
    [SerializeField]
     LayerMask m_BlockingMask = kNoEventMaskSet;
    // Start is called before the first frame update
    void Start()
    {
        var dir = transform.rotation * Vector3.forward;
        Debug.Log(dir);
    }

    // Update is called once per frame
    void Update()
    {
        Ray _ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rhit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out rhit, 10000))
            {
                Debug.Log(Vector3.Distance(_ray.origin, rhit.transform.position));
                Debug.Log(Vector3.Distance(_ray.origin, rhit.point));
                Debug.Log(rhit.distance);


                Debug.Log( Vector3.Dot(transform.forward, transform.position - _ray.origin) / Vector3.Dot(transform.forward, _ray.direction));
            }
        }     
    }
}
