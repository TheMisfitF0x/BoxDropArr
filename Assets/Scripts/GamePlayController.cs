using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public BoxSpawner box_Spawner;
    public int score;
    public Text scoretxt;
    private AudioSource[] soundSource;
    private AudioSource scoreSound;
    private AudioSource loseSound;
    

    [HideInInspector]
    public BoxScript currentBox;
    

    public CameraFollow cameraScript;
    private int moveCount;

    void Awake()
    {
        if (instance == null)
            instance = this;
        soundSource = GetComponents<AudioSource>();
        scoreSound = soundSource[0];
        loseSound = soundSource[1];
    }


    void Start()
    {
        score = 0;
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0) && !pauseMenu.isPaused)
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 0.8f);
    }

    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void addScore()
    {
        score++;
        scoretxt.text = "" + score;
        scoreSound.Play();
    }

    public void MoveCamera()
    {
        moveCount++;
        
        if(moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 1f;
        }
    }

    public void RestartGame()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        
    }

    public void playSound(int soundNum)
    {
        if (!loseSound.isPlaying)
        {
            if (soundNum == 1)
            {
                loseSound.Play();
            }
            else
            {
                scoreSound.Play();
            }
        }
    }
    //class
}

