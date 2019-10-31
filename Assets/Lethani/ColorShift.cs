using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour
{

    MeshRenderer m_renderer;
    Material m_material;

    string hueOffsetString = "hue_offset";
    void Start()
    {

        m_renderer = GetComponent<MeshRenderer>();
        m_material = m_renderer.material;
    }

    void Update()
    {
        Vector3 camPosition = Camera.main.transform.position;
        Vector3 targetPosition = transform.position;
        float distanceFromTargetToCamera = Vector3.Distance(targetPosition, camPosition);
        float hueOffset = distanceFromTargetToCamera * 11;
        m_material.SetFloat(hueOffsetString, hueOffset);

        Debug.Log(distanceFromTargetToCamera);
        
    }
}
