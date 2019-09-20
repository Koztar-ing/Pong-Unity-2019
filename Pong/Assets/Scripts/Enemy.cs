using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float bound = 4, playerSpeed = 0.25f;
    bool player2;
    GameObject ball;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerMovement();
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
}