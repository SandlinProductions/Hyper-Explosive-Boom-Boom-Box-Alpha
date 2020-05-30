using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Player Is Here");
        if (other.gameObject.tag =="Player")
        {
            GameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("Player Has Left");
        if(other.gameObject.tag=="Player")
        {
            GameObject.SetActive(false);
        }

    }
}
