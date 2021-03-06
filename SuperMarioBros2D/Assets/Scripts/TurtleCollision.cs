﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurtleCollision : MonoBehaviour
{
    public Turtle turtle;
    private float nextJump = 0f;
    private float jumpRate = 0.2f;
    private AudioSource sound;
    public AudioClip rebote;
    private GameObject mario;
    private GameObject padre;
    private GameObject scoreboard;
    void Start() {
        scoreboard = GameObject.Find("Canvas");
        sound = GetComponent<AudioSource>();
        mario = GameObject.FindWithTag("Mario");
        padre = transform.parent.gameObject;
    }
    public void Update() { 
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            if (turtle.dead && !turtle.deadcollision)
            {
                if (Time.time > nextJump)
                {
                    turtle.deadcollision = true;

                    if (turtle.gameObject.transform.position.x < collision.gameObject.transform.position.x)
                    {
                        turtle.direction = -1;
                    }
                    else
                    {
                        turtle.direction = 1;
                    }
                }
            }
            else if (turtle.deadcollision) {
                collision.gameObject.GetComponent<Mario>().hit(false);
            }

            else
            {
                collision.gameObject.GetComponent<Mario>().hit(false);
            }
        }

        else
        {
            if (collision.gameObject.tag != "Turtle")
            {
                if (!turtle.dead)
                {
                    turtle.direction = -turtle.direction;
                }

                else if (turtle.dead && turtle.deadcollision)
                {
                    
                    if (collision.gameObject.tag == "Wumpa")
                    {
                        //score
                        scoreboard.GetComponent<Scoreboard>().Score = scoreboard.GetComponent<Scoreboard>().Score + 100;
                        collision.gameObject.GetComponent<Goomba>().dead();
                    }
                    else
                    {
                        
                        
                            if (Vector2.Distance(mario.transform.position, gameObject.transform.position) < 10f)
                            {
                                sound.PlayOneShot(rebote, 1f);
                            }
                        
                        turtle.direction = -turtle.direction;
                    }
                }
            }
            if(collision.gameObject.tag == "Turtle" && collision.gameObject != padre &&turtle.dead)
            {
                collision.gameObject.GetComponent<Turtle>().deadFire();
            }
            if(collision.gameObject.tag == "Turtle" && collision.gameObject != padre &&!turtle.dead)
            {
                turtle.direction = -turtle.direction;
            }
        }
    }

}
