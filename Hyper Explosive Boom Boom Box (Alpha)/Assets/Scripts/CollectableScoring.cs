﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectableScoring : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;

    private void Start()
    {
        theScore = 0;
    }
    private void Update()
    {
        scoreText.GetComponent<Text>().text = theScore.ToString("");
    }
    
}
