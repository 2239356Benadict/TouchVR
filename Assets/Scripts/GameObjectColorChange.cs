using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectColorChange : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeColor;

    private Renderer cubeRenderer;

    private Color newCubeColor;

    private float randomR, randomG, randomB;
    void Start()
    {
        cubeRenderer = cubeColor.GetComponent<Renderer>();
        
    }

    public void ColorChangeMethod()
    {
        randomR = Random.Range(0f, 1f);
        randomG = Random.Range(0f, 1f);
        randomB = Random.Range(0f, 1f);

        newCubeColor = new Color(randomR, randomG, randomB, 1f);
        cubeRenderer.material.SetColor("_Color", newCubeColor);
    }

}
