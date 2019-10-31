using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public double frequency = 440.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0;

    public float gain = 0;
    public float volume = 0.1f;

    public float[] frequencies;
    public int thisFreq;

    public enum WaveType { SineWave, SquareWave };
    public WaveType _waveType = WaveType.SineWave;


    public float lowFrequency = 220;
    public float highFrequency = 440;

    AudioSource _audioSource;



    void Start()
    {


        _audioSource = GetComponent<AudioSource>();
        gain = volume;
        //_audioSource.Play();
       
    }

    public void Activate()
    {
        _audioSource.Play();
        frequency = lowFrequency;
        phase = 0;

    }

    public void Deactivate()
    {
        _audioSource.Stop();
    }

  
    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2 * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;

            if (_waveType == WaveType.SineWave)
            {
                data[i] = SampleSineWave();
            }

            if (_waveType == WaveType.SquareWave)
            {
                data[i] = SampleSquareWave();
            }

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }
        }
    }

    // Calling Method passes in a float between 0 and 1, which is then remapped to this OSC's freq range.
    public void ShiftFrequency(float percentFreqRange)
    {
        frequency = (double)percentFreqRange.RemapClamped( 0, 1, lowFrequency, highFrequency);
    }

    float SampleSineWave()
    {
        return (float)(gain * Mathf.Sin((float)phase));
    }

    float SampleSquareWave()
    {
        return gain * 0.6f * Mathf.Sign(gain * Mathf.Sin((float)phase));
    }

}

public static class ExtensionMethods
{

    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public static float RemapClamped(this float value, float from1, float to1, float from2, float to2)
    {
        return Mathf.Clamp( ( (value - from1) / (to1 - from1) * (to2 - from2) + from2), from2, to2);
    }


}

//    frequencies = new float[8];
//    frequencies[0] = 440;
//    frequencies[1] = 494;
//    frequencies[2] = 554;
//    frequencies[3] = 587;
//    frequencies[4] = 659;
//    frequencies[5] = 740;
//    frequencies[6] = 831;
//    frequencies[7] = 880;