using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apparate : MonoBehaviour
{

    public Material dissolveMat;


    private void Start()
    {
        dissolveMat.SetFloat("Alpha", 0);       
    }
}
