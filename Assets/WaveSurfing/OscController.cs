using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscController : MonoBehaviour
{

    public Oscillator _osc;
    public AudioViz _audioViz;

  

    void Update()
    {
        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);
        
        // The further the cam from the controller, the higher the frequency
        float freqShiftPercentage = distance.Remap(0, 30, 0, 1);
        _osc.ShiftFrequency(freqShiftPercentage);

        _audioViz.ShiftFrequency(freqShiftPercentage);
        
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {

    }
}
