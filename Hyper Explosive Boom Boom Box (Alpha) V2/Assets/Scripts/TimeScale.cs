using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public AudioClip slowMotionSound;
    public AudioClip restoreMotionSound;
    private GameObject Abilities;
    public GameObject SoundManager;
    public bool timeIsSlowed;

    private void Start()
    {
        Abilities = GameObject.FindWithTag("Skill");
        SoundManager = GameObject.FindWithTag("SoundManager");
    }
    //This is how we slow it all down.
    void Update()
    {
        if (Abilities.GetComponent<Abilities>().timeShift == true)
        {
            
            if (Input.GetButtonDown("Time") & PauseMenu.GameIsPaused == false)
            {
                if (Time.timeScale == 1.0F)
                    Time.timeScale = 0.2F;
                
                else
                    Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                timeIsSlowed = !timeIsSlowed;
                SlowSounds();
            }
 
        }
        if(GetComponent<PlayerController>().alive == false)
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            timeIsSlowed = false;
            GetComponent<TimeScale>().enabled = false;
        }
     
    }
    void SlowSounds()
    {
        if (timeIsSlowed == false)
            {
                SoundManager.GetComponent<SoundManager>().PlaySingle(restoreMotionSound);
            }
        if (timeIsSlowed == true)
        {
            SoundManager.GetComponent<SoundManager>().PlaySingle(slowMotionSound);
        }
    }
}
