using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private int _score = 10;
    // is called before the first frame update
    void Start()
    {
        //assign text component
        
        _scoreText.text = "Score: " + 0;
    }



    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();

    }
}
