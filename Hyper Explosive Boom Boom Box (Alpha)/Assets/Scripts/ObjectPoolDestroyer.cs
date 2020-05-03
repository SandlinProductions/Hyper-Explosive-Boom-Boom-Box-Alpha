using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolDestroyer : MonoBehaviour
{
    public float timeBeforeDestroy;

    private void OnEnable()
    {
        Invoke("Destroy", timeBeforeDestroy);
    }
    void Destroy()
    {
        gameObject.SetActive(false);  
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
