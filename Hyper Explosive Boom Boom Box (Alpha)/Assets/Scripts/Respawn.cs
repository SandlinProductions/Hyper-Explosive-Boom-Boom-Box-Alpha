using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{    //This Scrip will handle the respawning of the player. It will be the check if the player is alive or not.
    [Header("Respawn Location")]
    [Tooltip("The spot we will the play to be moved to after he has died.")]
    public Vector3 respawn; // The spot we will the play to be moved to after he has died.
    [Header("Respawn Effects")]
    public GameObject deathParticles;// The effect that will be released when the player dies.
    public GameObject respawnParticles;// The effect that will be released when the player comes back to life.
    public GameObject respawnSecondParticles;
    public GameObject playersRender;
    public CameraTracking cameraTracking;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bad Thing")
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        StartCoroutine(Dead());
        playersRender.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<PlayerController>().alive = false;
        cameraTracking.xFollowSpeed = 5f;
    }
    IEnumerator Dead()
    {
        
        transform.position = respawn;
        Debug.Log("I'm dead");
        yield return new WaitForSeconds(1);
        RespawnPlayer();
    }
    void RespawnPlayer()
    {

        Instantiate(respawnParticles, transform.position, Quaternion.identity);
        StartCoroutine(Alive());
    }
    IEnumerator Alive()
    {
        
        Debug.Log("Coming back alive");
        yield return new WaitForSeconds(1);
        Instantiate(respawnSecondParticles, transform.position,Quaternion.identity);
        playersRender.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<PlayerController>().alive = true;
        cameraTracking.xFollowSpeed = cameraTracking.currentFollow;
    }
}