using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    public ParticleSystem sparks;
    private void OnCollisionStay(Collision collision)
    {
        CreateSparks();
    }
    

    void CreateSparks()
    {
        sparks.Play();
        print("I'm making sparks");
    }
}
