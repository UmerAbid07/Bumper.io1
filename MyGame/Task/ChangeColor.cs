using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer playerRenderer;
    Color playerColor;
    float randomColor1, randomColor2, randomColor3;
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = gameObject.GetComponent<Renderer>();
    }

    public void changePlayerColor()
    {
        randomColor1 = Random.Range(0f, 1f);
        randomColor2 = Random.Range(0f, 1f);
        randomColor3 = Random.Range(0f, 1f);
        playerColor = new Color(randomColor1, randomColor2, randomColor3, 1f);
        playerRenderer.material.SetColor("_Color", playerColor);
    }
}
