using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool startedFromP1;
    [SerializeField] Button player1Button, player2Button;

    void Awake()
    {
        MakeSingleton();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
        {
            if(!player1Button)
            {
                player1Button = GameObject.Find("VsAiButton").GetComponent<Button>();
                player1Button.onClick.AddListener(VSAI);
            }
            if (!player2Button)
            {
                player2Button = GameObject.Find("VsPlayer2Button").GetComponent<Button>();
                player2Button.onClick.AddListener(VSPlayer2);
            }
        }
    }

    void MakeSingleton()
    {
        if (instance) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void VSAI()
    {
        startedFromP1 = true;
        SceneManager.LoadScene("Game");
    }

    void VSPlayer2()
    {
        startedFromP1 = false;
        SceneManager.LoadScene("Game");
    }
}
