using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 dir;
    public float speed = 3f;
    public string lasthit = "";
    public ScoreManager ScoreManager;
    private AudioSource audioSrc1;
    private AudioSource audioSrc2;

    // Start is called before the first frame update
    void Start()
    {
        //using polar coordinates, the direction of the ball is randomly determined in the beginning.
        gameObject.transform.position = new Vector3(0,0,1);
        float x = Random.value;
        if(x>0.5){
            float randir = Mathf.PI*Random.Range(0.7f,1.3f);
            dir.x = Mathf.Cos(randir);
            dir.y = Mathf.Sin(randir);
        }
        else{
            float randir = Mathf.PI*Random.Range(1.7f,2.3f);
            dir.x = Mathf.Cos(randir);
            dir.y = Mathf.Sin(randir);
        }

            audioSrc1 = GetComponent<AudioSource>();
            audioSrc1.clip = Resources.Load<AudioClip>("oof1");

            audioSrc2 = GetComponent<AudioSource>();
            audioSrc2.clip = Resources.Load<AudioClip>("oof2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir*speed*Time.deltaTime);
    }

    //simple collision. This will bounce between the two paddles for now.
    void OnCollisionEnter2D(Collision2D c){
        // when the ball hits a paddle, it will go back through the middle at a random point to bounce back.
        if(c.gameObject.CompareTag("PaddleLeft")){
            lasthit = "PaddleLeft";
            float rany = Random.Range(-2.5f,2.5f);
            float ranx = Random.Range(0f,0.5f);
            float disx = (ranx-transform.position.x)/2;
            float disy = (rany-transform.position.y)/2;
            dir = new Vector2(disx,disy);
            audioSrc1.Play();
        }
        else if(c.gameObject.CompareTag("PaddleRight")){
            lasthit = "PaddleRight";
            float rany = Random.Range(-2.5f,2.5f);
            float ranx = Random.Range(-0.5f,0);
            float disx = (ranx-transform.position.x)/2;
            float disy = (rany-transform.position.y)/2;
            dir = new Vector2(disx,disy);
            audioSrc2.Play();
        }
        // if the ball hits a boundary collision it will alert who won the round and reset the ball in the middle of the arena
        else if(c.gameObject.CompareTag("Right Boundary")){
            ScoreManager.Player1Goal();
            Start();
        }
        else if(c.gameObject.CompareTag("Left Boundary")){
            ScoreManager.Player2Goal();
            Start();
        }
        
     }
}
