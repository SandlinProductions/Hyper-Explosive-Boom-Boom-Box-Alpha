using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    public ParticleSystem sparks;
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
            Instantiate(sparks, contact.point, Quaternion.identity);
        print("I'm making sparks");
    }

}
