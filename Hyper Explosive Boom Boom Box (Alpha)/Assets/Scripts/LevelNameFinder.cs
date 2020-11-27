using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNameFinder : MonoBehaviour
{
    private GameObject levelSelector;
    public LSUIMenu levelSelectorUI;
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        levelSelectorUI = FindObjectOfType<LSUIMenu>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Selector")
        {
            levelSelector = collision.gameObject;
            FindLevelName();
        }
        
    }

    void FindLevelName()
    {
        levelName = levelSelector.GetComponent<LevelSelector>().levelName;

    }
}
