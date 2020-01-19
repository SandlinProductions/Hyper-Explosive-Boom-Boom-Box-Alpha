using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSize : MonoBehaviour {

    public Vector3 bigger;
    public Vector3 smaller;
    public Vector3 normal;
    public float bigMass;
    public float smallMass;
    public bool isBigger;
    public bool isSmaller;
    public bool isAxisInUse;
    public GameObject Abilities;

    private void Start()
    {
        Abilities = GameObject.FindWithTag("Skill");
        normal = transform.localScale;
        isBigger = false;
        isSmaller = false;
        isAxisInUse = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Abilities.GetComponent<Abilities>().changingSize == true)
        {
            if (Input.GetAxisRaw("Bigger") > 0)
            {
                print("Bigger!");
                if (isAxisInUse == false)
                {
                    GetBig();
                    print("Bigger");
                    isAxisInUse = true;
                }

            }
            if (Input.GetAxisRaw("Smaller") < 0)
            {
                print("Smaller!");
                if (isAxisInUse == false)
                {
                    GetSmall();
                    print("Smaller");
                    isAxisInUse = true;
                }

            }
            if (isBigger == true & Input.GetAxisRaw("Smaller") < 0)
            {
                NormalSize();
                isAxisInUse = true;
                Debug.Log("Normal");
            }
            if (isSmaller == true & Input.GetAxisRaw("Bigger") > 0)
            {

                NormalSize();
                print("Normal");
                isAxisInUse = true;

            }
            if (Input.GetAxisRaw("Bigger") == 0)
            {
                isAxisInUse = false;
            }
            if (Input.GetAxisRaw("Smaller") == 0)
            {
                isAxisInUse = false;
            }
        }
    }
         
    public void GetBig()
    {
        transform.localScale = bigger;
        GetComponent<Rigidbody>().mass = bigMass;
        isBigger = true;
    }
    public void GetSmall()
    {
        transform.localScale = smaller;
        GetComponent<Rigidbody>().mass = smallMass;
        isSmaller = true;
    }

    public void NormalSize()
    {
        transform.localScale = normal;
        GetComponent<Rigidbody>().mass = 1f;
        isBigger = false;
        isSmaller = false;
    }
}
