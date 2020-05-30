using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWallStick : MonoBehaviour
{
    public GameObject Abilities;
    private void Start()
    {
        Abilities = GameObject.FindWithTag("Skill");
        if (Abilities.GetComponent<Abilities>().wallStick == true)
        {
            gameObject.SetActive(false);
        }
        else if (Abilities.GetComponent<Abilities>().wallStick == false)
            gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
       Abilities.GetComponent<Abilities>().wallStick = true;
        gameObject.SetActive(false);
    }
}
