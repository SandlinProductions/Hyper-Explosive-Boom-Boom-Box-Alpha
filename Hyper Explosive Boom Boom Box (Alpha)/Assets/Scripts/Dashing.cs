using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 1f;
    public float dashSpeed = 5f;

    public GameObject dashParticles;
    public GameObject dashBlast;

    private GameObject Abilities;
    // Start is called before the first frame update
    void Start()
    {
        Abilities = GameObject.FindWithTag("Skill");
    }

    // Update is called once per frame
    void Update()
    {
        if(Abilities.GetComponent<Abilities>().dash == true)
            switch (dashState)
        {
                case DashState.Ready:
                    var isDashKeyDown = Input.GetButtonDown("Dash");
                    if(isDashKeyDown)
                    {
                        GetComponent<PlayerMovement>().moveForce =
                            GetComponent<PlayerMovement>().moveForce * dashSpeed;
                        Instantiate(dashParticles, transform.position, Quaternion.identity);
                        Instantiate(dashBlast, transform.position, Quaternion.identity);
                        dashState = DashState.Dashing;
                        print("am I Dashing");
                    }
                    break;
                case DashState.Dashing:
                    dashTimer += Time.deltaTime * 3;
                    if(dashTimer >= maxDash)
                    {
                        GameObject clone = (GameObject)Instantiate
                            (dashParticles, transform.position, transform.rotation);
                        clone.transform.parent = transform;
                        dashTimer = maxDash;
                        dashState = DashState.Cooldown;
                    }
                    break;
                case DashState.Cooldown:
                    dashTimer -= Time.deltaTime;
                    if(dashTimer <= 0)
                    {
                        GetComponent<PlayerMovement>().moveForce = 950f;
                        print("I'm not dashing anymore");
                        dashTimer = 0;
                        dashState = DashState.Ready;
                    }
                    break;

        }
    }
    public enum DashState
    {
        Ready,
        Dashing,
        Cooldown
    }
}
