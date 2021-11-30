using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalikkaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Abs(UnityEditor.TransformUtils.GetInspectorRotation(transform).x);
        float y = Mathf.Abs(UnityEditor.TransformUtils.GetInspectorRotation(transform).y);
        float z = Mathf.Abs(UnityEditor.TransformUtils.GetInspectorRotation(transform).z);
        if ((x > 1 || y > 1 || z > 1)) {
            Destroy(gameObject, 3);
        }

    }
}
