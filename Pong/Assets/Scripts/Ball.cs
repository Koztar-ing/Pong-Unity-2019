using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    int score;
    float speed = 4.5f;
    ScoreController scoreController;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.AddForce(new Vector2(speed * 50, 0));
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    void Update()
    {
        Bounds();
    }

    void Bounds()
    {
        if(transform.position.x > 8.5f)
        {
            score = 1;
            scoreController.AddScoreToPlayer1();
            StartCoroutine(StartOverAgain());
        }
        else if (transform.position.x < -8.5f)
        {
            score = 0;
            scoreController.AddScoreToEnemy();
            StartCoroutine(StartOverAgain());
        }
    }

    void NewStart()
    {
        if (score == 1) rigidBody2D.AddForce(new Vector2(speed * 50, 0));
        else if (score == 0) rigidBody2D.AddForce(new Vector2(-speed * 50, 0));
    }

    void GoBack()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }

    IEnumerator StartOverAgain()
    {
        GoBack();
        yield return new WaitForSeconds(2f);
        NewStart();
    }
}