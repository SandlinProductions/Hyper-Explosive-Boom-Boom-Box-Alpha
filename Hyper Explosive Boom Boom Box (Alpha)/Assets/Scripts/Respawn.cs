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

    private void Start()
    {
        cameraTracking = GetComponent<CameraTracking>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bad Thing")
        {
            transform.parent = null;
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
        //cameraTracking.xFollowSpeed = 5f;
    }
    IEnumerator Dead()
    {
        
        Debug.Log("I'm dead");
        yield return new WaitForSeconds(1);
        RespawnPlayer();
    }
    void RespawnPlayer()
    {
        // transform.position = respawn;
        //GetComponent<PlayerPhysics>().gravityScale = 5f;
        //GetComponent<PlayerJumping>().jump = 25f;
        Instantiate(respawnParticles, transform.position, Quaternion.identity);
        StartCoroutine(Alive());
        //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    IEnumerator Alive()
    {
        //Instantiate(respawnSecondParticles, transform.position, Quaternion.identity);
        Debug.Log("Coming back alive");
        yield return new WaitForSeconds(1);
        //Instantiate(respawnSecondParticles, transform.position,Quaternion.identity);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        //playersRender.GetComponent<Renderer>().enabled = true;
        //gameObject.GetComponent<BoxCollider>().enabled = true;
        //GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY
        // & ~RigidbodyConstraints.FreezePositionX
        // & ~RigidbodyConstraints.FreezeRotationZ;
        //GetComponent<PlayerController>().alive = true;
        //cameraTracking.xFollowSpeed = cameraTracking.currentFollowX;
    }
}