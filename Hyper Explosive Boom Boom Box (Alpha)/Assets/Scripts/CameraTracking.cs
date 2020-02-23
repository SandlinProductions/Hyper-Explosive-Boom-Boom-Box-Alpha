using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
   
    public Transform trackingTarget;
    [SerializeField]
    public float xOffset;
    [SerializeField]
    public float yOffset;
    [SerializeField]
    public float xFollowSpeed;
    [SerializeField]
    public float yFollowSpeed;
    public PlayerController playerController;
    public bool isZoomedOout;
    public float currentFollowX;
    public float currentFollowY;
    private Transform thePlayer;

    private void Start()
    {
        currentFollowX = xFollowSpeed;
        currentFollowY = yFollowSpeed;
        thePlayer = Transform.FindObjectOfType<PlayerController>().transform;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
       
            if (playerController.facingRight== true)
        {
                float xTarget = trackingTarget.position.x + xOffset;
                float yTarget = trackingTarget.position.y + yOffset;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * xFollowSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * yFollowSpeed);

                transform.position = new Vector3(xNew, yNew, transform.position.z);
            }
            else if (playerController.facingRight== false)
        {
                float xTarget = trackingTarget.position.x + -xOffset;
                float yTarget = trackingTarget.position.y + yOffset;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * xFollowSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * yFollowSpeed);

                transform.position = new Vector3(xNew, yNew, transform.position.z);
            }
        if (playerController.alive == false)
        {
            Dead();
        }
       
     
    }

    void Dead()
    {
        xOffset = 0;
        trackingTarget = thePlayer;
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 29, Time.deltaTime * 1);
    }
        
    

}
