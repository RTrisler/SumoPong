using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public int speed = 90;
    public Vector3 dir;
    Vector3 rotationPoint = new Vector3(0,0,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for the paddles to move in a circular fashion, the RotateAround transformation is used around 0,0
        if(gameObject.CompareTag("PaddleRight")){
            if(Input.GetKey(KeyCode.UpArrow)){
                if(gameObject.transform.position.x>1 && gameObject.transform.position.y<4f){
                    transform.RotateAround(dir,rotationPoint,speed*Time.deltaTime);
                }
            }

            if(Input.GetKey(KeyCode.DownArrow)){
                if(gameObject.transform.position.x>1 && gameObject.transform.position.y>-4f){
                    transform.RotateAround(dir,rotationPoint,-speed*Time.deltaTime);
                }
            }
        }
        if(gameObject.CompareTag("PaddleLeft")){
            if(Input.GetKey(KeyCode.W)){
                if(gameObject.transform.position.x<-1 && gameObject.transform.position.y<4f){
                    transform.RotateAround(dir,rotationPoint,-speed*Time.deltaTime);
                }
            }
            if(Input.GetKey(KeyCode.S)){
                if(gameObject.transform.position.x<-1 && gameObject.transform.position.y>-4f){
                    transform.RotateAround(dir,rotationPoint,speed*Time.deltaTime);
                }
            }
        }
    }
}
