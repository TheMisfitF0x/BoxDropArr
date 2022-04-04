using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour {

    public static GameplayController instance;

    public BoxSpawner box_Spawner;

    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    void Start()
    {
        box_spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //class
}

