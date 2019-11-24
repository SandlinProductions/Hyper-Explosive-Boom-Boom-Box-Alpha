using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {
    //We use this script to make our player teleport around to a specific location when the player touches the collider
    public Vector3 teleportSpawn;//where the player ends up at
    public GameObject player;//what we want to teleport (the player)
    public GameObject teleportParticles;//effect that happens when the player touches the teleport


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Teleport();
        }
    }

    void Teleport()
    {
        print("Teleport");
        Instantiate(teleportParticles, player.transform.position, Quaternion.identity);
        player.gameObject.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(Warp());
    }

    IEnumerator Warp()
    {
    Debug.Log("Warping");
        yield return new WaitForSeconds(1);
        player.transform.position = teleportSpawn;
        Instantiate(teleportParticles,player.transform.position, Quaternion.identity);
        player.gameObject.GetComponent<Renderer>().enabled = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Debug.Log("Player has been Teleported");
    }
  
}
