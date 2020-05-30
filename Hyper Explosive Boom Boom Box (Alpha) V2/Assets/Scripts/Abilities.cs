using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    //This holds what Abilites are unlocked
    public bool dash;
    public bool timeShift;
    public bool wallStick;
    public bool changingSize;

    //At the Start of the game all abilites should be set to false until player unlocks them.
    void Awake()
    {
        dash = false;
        timeShift = false;
        wallStick = false;
        changingSize = false;
    }
}
