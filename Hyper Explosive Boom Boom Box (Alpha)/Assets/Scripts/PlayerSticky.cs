using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSticky : MonoBehaviour
{
    private bool grounded;
    public Abilities Abilities;


    //Check if Grounded
    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
        if (collision.gameObject.tag == "Bad Thing")
        {
            transform.parent = null;
        }

        if (grounded == true)
        {
            Stick();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
        GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY
               & ~RigidbodyConstraints.FreezePositionX
               & ~RigidbodyConstraints.FreezeRotationZ;
        Debug.Log("I should be free");
    }

    void Stick()
    {
        if (Abilities.GetComponent<Abilities>().wallStick == true)
        {


            if (Input.GetKeyDown(KeyCode.Tab) || (Input.GetButtonDown("Sticky")))
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                print("am I sticking to this?");
            }
            if (Input.GetKeyUp(KeyCode.Tab) || (Input.GetButtonUp("Sticky")))
            {
                GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY
                    & ~RigidbodyConstraints.FreezePositionX
                    & ~RigidbodyConstraints.FreezeRotationZ;
                print("am I un Sticking to this");
            }
        }
    }


}
