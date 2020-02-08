using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableUpdating : MonoBehaviour
{
    public AudioClip collectingSound;

    private bool collected;

    public Transform trackingTarget;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;
    [SerializeField]
    float followSpeed;
    public PlayerController playerController;
    public GameObject particle;
    public GameObject SoundManager;
    public float time;

    private void Start()
    {
        SoundManager = GameObject.FindWithTag("SoundManager");
    }

    private void Update()
    {
        if(collected == true)
        {
            if (playerController.facingRight == true)
            {
                float xTarget = trackingTarget.position.x + xOffset;
                float yTarget = trackingTarget.position.y + yOffset;
                float zTarget = trackingTarget.position.z;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
                float zNew = Mathf.Lerp(transform.position.z, zTarget, Time.deltaTime * followSpeed);
             

                transform.position = new Vector3(xNew, yNew, zNew);
            }
            else if (playerController.facingRight == false)
            {
                float xTarget = trackingTarget.position.x + -xOffset;
                float yTarget = trackingTarget.position.y + yOffset;
                float zTarget = trackingTarget.position.z;

                float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
                float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
                float zNew = Mathf.Lerp(transform.position.z, zTarget, Time.deltaTime * followSpeed);

                transform.position = new Vector3(xNew, yNew, zNew);
            }
            particle.transform.RotateAround(Vector3.zero, Vector3.up, followSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //GetComponent<MeshCollider>().isTrigger = true;
            SoundManager.GetComponent<SoundManager>().RandomizeSfx(collectingSound);
            collected = true;
            CollectableScoring.theScore += 1;
            StartCoroutine(Collected());
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.GetComponent<SoundManager>().RandomizeSfx(collectingSound);
            collected = true;
            CollectableScoring.theScore += 1;
            StartCoroutine(Collected());
        }
    }
    IEnumerator Collected()
    {
        Debug.Log("Starting");
        yield return new WaitForSeconds(time);
        //Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
