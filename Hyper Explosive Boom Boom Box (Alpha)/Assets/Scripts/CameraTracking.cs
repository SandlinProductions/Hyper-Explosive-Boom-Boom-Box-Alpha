using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
   
    public Transform trackingTarget;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;
    [SerializeField]
    public float xFollowSpeed;
    [SerializeField]
    public float yFollowSpeed;
    public PlayerController playerController;
    public bool isZoomedOout;
    public float currentFollowX;
    public float currentFollowY;

    private void Start()
    {
        currentFollowX = xFollowSpeed;
        currentFollowY = yFollowSpeed;

       
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
       
            if (playerController.facingRight == true)
            {
                float xTarget = trackingTarget.position.x + xOffset;
                float yTarget = trackingTarget.position.y + yOffset;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * xFollowSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * yFollowSpeed);

                transform.position = new Vector3(xNew, yNew, transform.position.z);
            }
            else if (playerController.facingRight == false)
            {
                float xTarget = trackingTarget.position.x + -xOffset;
                float yTarget = trackingTarget.position.y + yOffset;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * xFollowSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * yFollowSpeed);

                transform.position = new Vector3(xNew, yNew, transform.position.z);
            }
       
     
    }
        
    

}
