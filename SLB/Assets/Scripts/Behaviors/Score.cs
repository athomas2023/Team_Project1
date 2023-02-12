using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    public int scoreCount;
    public TextMeshProUGUI score_Text;
    // Start is called before the first frame update
    void Start()
    {
        score_Text.text = "Score:" + scoreCount.ToString();
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_Text.text = "Score:" + scoreCount.ToString();
    }


    public void Change_Score(int points)
    {
        scoreCount = scoreCount + points;
    }
}
