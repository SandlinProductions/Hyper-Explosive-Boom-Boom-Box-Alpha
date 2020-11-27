using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LSUIMenu : MonoBehaviour
{
    private LevelNameFinder levelNameFinder;
    private LevelSelector levelSelector;
    public string levelName;
    public bool readyForName;
    public TextMeshProUGUI levelNameText;
    // Start is called before the first frame update
    void Start()
    {
        levelNameFinder = FindObjectOfType<LevelNameFinder>();
        levelSelector = FindObjectOfType<LevelSelector>();
    }

    private void Update()
    {
        if(readyForName == true)
        {
            FindLevelName();
            LevelText();
        }
    }

    public void LoadLevel(string name)
    {
        name = levelName;
        SceneManager.LoadScene(name);
    }
    void FindLevelName()
    {
        levelName = levelNameFinder.GetComponent<LevelNameFinder>().levelName;

    }
    void LevelText()
    {
        levelNameText.gameObject.GetComponent<TextMeshProUGUI>().text = levelName;
    }
    
}
