using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public BoxSpawner box_Spawner;
    public GameObject platform;

    public int score;

    public Sprite audioMutedImg;
    public Sprite audioImg;
    public Sprite musicMutedImg;
    public Sprite musicImg;

    private int highScore;
    public static bool musicIsMuted;
    public static bool audioIsMuted;

    public Text scoretxt;
    public Text highscoretxt;

    private AudioSource[] soundSource;
    private AudioSource scoreSound;
    private AudioSource loseSound;
    private AudioSource musicSound;

    public Button muteAudioButton;
    public Button muteMusicButton;
    
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
        musicSound = soundSource[2];
    }

    void Start()
    {
        score = 0;
        highscoretxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        scoreSound.volume = PlayerPrefs.GetFloat("Volume", 1);
        loseSound.volume = PlayerPrefs.GetFloat("Volume", 1);
        musicSound.volume = PlayerPrefs.GetFloat("Music", .5f);

        if(PlayerPrefs.GetInt("AudioMuted", 0) == 1)
        {
            scoreSound.mute = true;
            loseSound.mute = true;
            audioIsMuted = true;

            muteAudioButton.image.sprite = audioMutedImg;
        }

        if (PlayerPrefs.GetInt("MusicMuted",0) == 1)
        {
            musicSound.mute = true;
            musicIsMuted = true;

            muteMusicButton.image.sprite = musicMutedImg;
        }

        box_Spawner.SpawnBox();

        pauseMenu.isPaused = false;

        switch(PlayerPrefs.GetInt("PlatformSize", 2))
        {
            case 1:
                {
                    platform.transform.localScale = new Vector3((float).3, platform.transform.localScale.y, platform.transform.localScale.z);
                    break;
                }

            case 2:
                {
                    platform.transform.localScale = new Vector3((float).78, platform.transform.localScale.y, platform.transform.localScale.z);

                    break;
                }

            case 3:
                {
                    platform.transform.localScale = new Vector3((float)1.2, platform.transform.localScale.y, platform.transform.localScale.z);
                    break;
                }

            default:
                {
                    platform.transform.localScale = new Vector3((float).78, platform.transform.localScale.y, platform.transform.localScale.z);
                    break;
                }
        }
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

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoretxt.text = "" + score;
        }
    }

    public void MoveCamera()
    {
        moveCount++;
        
        if(moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 1.5f;
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

    public void toggleAudio()
    {
        if(audioIsMuted == false)
        {
            scoreSound.mute = true;
            loseSound.mute = true;
            audioIsMuted = true;
            PlayerPrefs.SetInt("AudioMuted", 1);

            muteAudioButton.image.sprite = audioMutedImg;
        }
        else
        {
            scoreSound.mute = false;
            loseSound.mute = false;
            audioIsMuted = false;
            PlayerPrefs.SetInt("AudioMuted", 0);

            muteAudioButton.image.sprite = audioImg;
        }
    }

    public void toggleMusic()
    {
        if (musicIsMuted == false)
        {
            musicSound.mute = true;
            musicIsMuted = true;
            PlayerPrefs.SetInt("MusicMuted", 1);

            muteMusicButton.image.sprite = musicMutedImg;
        }
        else
        {
            musicSound.mute = false;
            musicIsMuted = false;
            PlayerPrefs.SetInt("MusicMuted", 0);

            muteMusicButton.image.sprite = musicImg;
        }
    }
    //class
}

