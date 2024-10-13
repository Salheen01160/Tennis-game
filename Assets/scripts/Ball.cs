using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public player playerr;
    public float Ball_speed;
    Vector3 velocity;
    Rigidbody2D r2d;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        if (LevelManager.instance.diffculty == 1)
        {
            Ball_speed = 9;
        }
        else if (LevelManager.instance.diffculty == 2)
        {
            Ball_speed = 13;
        }
        else if (LevelManager.instance.diffculty == 3)
        {
            Ball_speed =20;
        }


    }

    void Update()
    {
        velocity = r2d.velocity;
    }
    public void startBallMove()
    {
        float angale = Random.Range(0, 360);
        Vector3 dircation = new Vector3(Mathf.Cos(angale), Mathf.Sin(angale), 0);
        r2d.velocity = dircation * Ball_speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionTag = collision.collider.tag;
        if (collision.collider.tag == "Wall")
        {
            ContactPoint2D[] points = collision.contacts;
            Vector3 new_velocity = Vector3.Reflect(velocity, points[0].normal);
            r2d.velocity = new_velocity;
        }
        else if (collision.collider.tag == "outp" || collision.collider.tag == "outc")
        {
           
            transform.position=new Vector3(0,0, 0); 
            r2d.velocity=new Vector3(0,0, 0);
            playerr.is_started = false;

            if (collision.collider.tag == "outp")
            {
                if (playerr.Myscore>0)
                {
                    playerr.Myscore--;
                    if (playerr.Myscore==0)
                    {
                        playerr.GameOverPanel.SetActive(true);
                        playerr.ResultTXT.text = "You Lost -_-";
                        Debug.Log("You Lost");
                    }
                }
               
            }
            else
            {
                if (playerr.CpuScore>0)
                {
                    playerr.CpuScore--;
                    if (playerr.CpuScore == 0)
                    {
                        playerr.GameOverPanel.SetActive(true);

                        Debug.Log("You Won");
                    }
                }
                
            }
        }
    }
}
