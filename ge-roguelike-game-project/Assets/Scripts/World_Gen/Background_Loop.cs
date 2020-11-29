using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Background_Loop : MonoBehaviour
{
    public GameObject background;
   
    private Camera mainCamera;
    
    private float camWidth;
    private float camHeight;
    private float camPosition;
    private float spawnBound_X;
    private float spawnBound_Y;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        camHeight = 2f * mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

        spawnBound_X = 2f * camWidth;
        spawnBound_Y = 2f * camHeight;
    }
}
