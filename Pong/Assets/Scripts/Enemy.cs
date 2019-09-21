using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 move = Vector3.zero;
    float bound = 4, playerSpeed = 0.25f, aiSpeed = 4.5f;
    bool player2;
    GameObject ball;
    ScoreController scoreController;

    void Start()
    {
        ball = GameObject.Find("Ball");
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    void Update()
    {
        if(player2) PlayerMovement();
        else AIMovement();
        Bounds();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.position = new Vector2(transform.position.x, transform.position.y + playerSpeed);
        else if (Input.GetKey(KeyCode.DownArrow)) transform.position = new Vector2(transform.position.x, transform.position.y - playerSpeed);
    }

    void Bounds()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -bound, bound));
    }

    void AIMovement()
    {
        float direction = ball.transform.position.y - transform.position.y;
        if (direction > 0) move.y = aiSpeed * Mathf.Min(direction, 1.5f);
        if (direction < 0) move.y = -aiSpeed * Mathf.Min(-direction, 1.5f);
        transform.position += move * Time.deltaTime;
    }
}