using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private float min_X = -2.2f, max_X = 2.2f;

    private bool canMove;
    private float move_Speed = 2f;

    private Rigidbody2D myBody;
    private AudioSource soundSource;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        move_Speed = PlayerPrefs.GetFloat("SpawnerSpeed", 2);

        if(Random.Range(0, 2) > 0)
        {
            move_Speed *= -1f;
        }

        GameplayController.instance.currentBox = this;

    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;
            
            if(temp.x > max_X)
            {
                move_Speed *= -1f;
            }
            else if(temp.x < min_X)
            {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        
        if (gameOver)
            return;


        ignoreCollision = true;
        ignoreTrigger =  true;

        GameplayController.instance.SpawnNewBox();
        GameplayController.instance.MoveCamera();          
    }

    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Platform" | target.gameObject.tag == "Box")
        {
            if (GameplayController.audioIsMuted == false)
            {
                soundSource.Play();
            }

            if (ignoreCollision)
                return;
            GameplayController.instance.addScore();
            Invoke("Landed", 0.8f);
            ignoreCollision = true;
        }
       
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        

        //gameObject was added from 2nd video
        //if(target.tag == "GameOver")
        if (target.gameObject.tag == "GameOver")
        {
            GameplayController.instance.playSound(1);
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("RestartGame", 1.5f);
        }
        
    }
}
