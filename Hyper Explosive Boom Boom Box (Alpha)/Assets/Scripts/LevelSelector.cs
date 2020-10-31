using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject player;
    public GameObject levelSelectorUI;
    public string levelName;

    private void Start()
    {
        levelSelectorUI.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("I'm touching the Level Selector");
            levelSelectorUI.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject == player)
        {
            Debug.Log("I stepped off the Level Selector");
            levelSelectorUI.SetActive(false);
        }
    }
}
