using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz : MonoBehaviour
{

    public float frequency = 1;
    public float amplitude = 1;
    public float speed = 0.01f;

    public float lowFrequency = .1f;
    public float highFrequency = 2;


    Vector3 currentPosition;
    Vector3 originalPosition;

    public float wrapDistance = 5;


    ParticleSystem _ps;
    ParticleSystem.EmissionModule _emission;


    // Update is called once per frame


    private void Start()
    {
        originalPosition = transform.position;
        currentPosition = originalPosition;
        _emission = GetComponent<ParticleSystem>().emission;
    }

    public void ShiftFrequency(float freqShiftPercentage)
    {
        frequency = freqShiftPercentage.Remap(0, 1, lowFrequency, highFrequency);

    }

    void Update()
    {

        float currentXPosition = transform.localPosition.x;
        if (Mathf.Abs(currentPosition.x - originalPosition.x) > wrapDistance)
        {
            _emission.enabled = false;
            currentPosition.x = originalPosition.x;
        }
        else
        {
            _emission.enabled = true;
        }

        currentPosition.y = amplitude * Mathf.Sin(Time.time * Mathf.PI * 2 * frequency);
        currentPosition = new Vector3(currentPosition.x + speed, currentPosition.y, 0);
        transform.localPosition = currentPosition;






    }
}
