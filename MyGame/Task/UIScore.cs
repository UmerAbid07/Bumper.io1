using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score :" + score.ToString();
    }
    public void incrementScore(float amount)
    {
        score += amount;
    }
}
