using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public GameObject Background; 
    private Renderer backgroundRenderer;

    public float scrollSpeed = 1.0f; //Stores background scrolling speed

    void Start()
    {
        backgroundRenderer = Background.GetComponent<Renderer>();
    }

    void Update()
    {
        //Renders quad which background image is placed on and makes it scroll
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        backgroundRenderer.material.mainTextureOffset = offset;
    }
}
