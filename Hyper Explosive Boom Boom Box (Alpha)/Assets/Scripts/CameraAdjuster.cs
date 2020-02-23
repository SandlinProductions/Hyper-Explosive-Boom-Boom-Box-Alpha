using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    [Header("Zone Setting")]
    [SerializeField]
    private int newFieldOfView;//sets the Field of View for the camera attached to this script.
    [SerializeField]
    private float newOffSetX;
    [SerializeField]
    private float newOffSetY;
    [SerializeField]
    [Tooltip("Speed to reach the new FieldOfView (Lower the Slower")]
    private float smoothZooming;//sets the speed of how long it takes for the camera to reach the set Field of View (the lower the Slower).
    private float normal; //this is the normal setting for the camera's Field of View.
    private float normalOffSetX;
    private float normalOffSetY;
    [SerializeField]
    [Tooltip("What the Camera will focus on while in the Zone")]
    private Transform cameraFocus;//this is what we want the Camera to focus on while we are in the zone.
    [Header("Camera and Scripts to Access")]
    [SerializeField]
    private Camera mainCamera;//this is where we put the Main Camera to access it.
    [SerializeField]
    private CameraTracking cameraTracking;//this is where we put the Main Camera to access the CameraTricking Script.
    private Transform playerFocus;//this is what the Main Camera is normaly focused on.
    public PlayerController PlayerController;
    void Start()
    {
        normal = mainCamera.GetComponent<Camera>().fieldOfView;//this grabs the Field of View from the Main Camera.
        playerFocus = cameraTracking.GetComponent<CameraTracking>().trackingTarget;//this grabs the tracking target of the Main Camera (will normaly be the player)
        normalOffSetX = mainCamera.GetComponent<CameraTracking>().xOffset;
        normalOffSetY = mainCamera.GetComponent<CameraTracking>().yOffset;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.GetComponent<Camera>().fieldOfView, newFieldOfView, Time.deltaTime * smoothZooming);//this changes the field of view to the new settings
            cameraTracking.GetComponent<CameraTracking>().isZoomedOout = true; // this marks the Main Camera as zooming.
            cameraTracking.GetComponent<CameraTracking>().trackingTarget = cameraFocus;//this makes the Main Camera focus change to want we want while in the zone
            cameraTracking.GetComponent<CameraTracking>().xOffset = newOffSetX;
            cameraTracking.GetComponent<CameraTracking>().yOffset = newOffSetY;
            if(PlayerController.GetComponent<PlayerController>().alive == false)
            {
                cameraTracking.GetComponent<CameraTracking>().trackingTarget = playerFocus;
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smoothZooming);//this changes back the Main Camera Field of View to what it was at the start
            cameraTracking.GetComponent<CameraTracking>().isZoomedOout = false;//this marks the came as not zooming anymore
            cameraTracking.GetComponent<CameraTracking>().trackingTarget = playerFocus;//this changes back the focus to the player after leaving the zone.
            cameraTracking.GetComponent<CameraTracking>().xOffset = normalOffSetX;
            cameraTracking.GetComponent<CameraTracking>().yOffset = normalOffSetY;
        }
    }
}
