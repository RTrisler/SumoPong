using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    public GameObject ball;
    public GameObject PaddleLeft;
    public GameObject PaddleRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject;
        if (ball.GetComponent<Ball>().lasthit == "PaddleLeft")
        {
            Debug.Log("PaddleLeftPowerUp");
            Destroy(gameObject);
            powerupEffect.Apply(PaddleLeft);
        }
        
    }
}
