using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
    //This controls the Gravity for the different Zone.
    public float levelOfGravity = 0f;
    public float FloatStrenght;
    public float jumpStrenght;
    public GameObject effectedObject;
    private float startGravity;

    public void Start()
    {
        startGravity = effectedObject.GetComponent<PlayerPhysics>().gravityScale;
    }



    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            effectedObject.gameObject.GetComponent<PlayerPhysics>().gravityScale = levelOfGravity;
            effectedObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * FloatStrenght);
            effectedObject.gameObject.GetComponent<PlayerJumping>().jump = jumpStrenght;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        effectedObject.gameObject.GetComponent<PlayerJumping>().jump = 25f;
        effectedObject.GetComponent<PlayerPhysics>().gravityScale = startGravity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(effectedObject.gameObject.GetComponent<PlayerController>().alive ==false)
        {
            Debug.Log("Starting Reset");
            Reset();
        }
    }
    private void Reset()
    {
        effectedObject.GetComponent<PlayerPhysics>().gravityScale = startGravity;
        effectedObject.gameObject.GetComponent<PlayerJumping>().jump = 25f;
        Debug.Log("Finshing Reset");
    }
}