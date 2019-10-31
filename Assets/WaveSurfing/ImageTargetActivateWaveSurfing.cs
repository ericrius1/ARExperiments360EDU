using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetActivateWaveSurfing : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehavior;
    public Oscillator _osc;
    public OscController _oscController;

    void Start()
    {
        mTrackableBehavior = GetComponent<TrackableBehaviour>();
        if (mTrackableBehavior)
        {
            mTrackableBehavior.RegisterTrackableEventHandler(this);
        }

    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("TRACCKED!!!");
            _osc.Activate();
            _oscController.Activate();
        }


        // We've lost the image so turn off the synth
        if(newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            _osc.Deactivate();
            _oscController.Deactivate();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
