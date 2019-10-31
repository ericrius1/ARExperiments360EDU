using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 currentPosition;
    Vector3 prevPosition;

    MeshRenderer m_renderer;
    Material m_material;

    string noiseStrengthString = "noise_strength";

    float noiseStrength;

    public float maxStrength = 1;
    void Start()
    {
        currentPosition = transform.position;
        prevPosition = currentPosition;

        m_renderer = GetComponent<MeshRenderer>();
        m_material = m_renderer.material;
        noiseStrength = m_material.GetFloat(noiseStrengthString);

        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;

        if (Vector3.Distance(currentPosition, prevPosition) > 2f)
        {

            //Debug.Log("SHAKE " + noiseStrength);

            if (noiseStrength < maxStrength)
            {
                noiseStrength += 0.1f;
                m_material.SetFloat(noiseStrengthString, noiseStrength);
            }

        }

        prevPosition = currentPosition;
        
    }
}
