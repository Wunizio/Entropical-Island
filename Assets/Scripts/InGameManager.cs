using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{

    public ChonkGeneration generator;
    public Fade fader;

    private bool isEnd;
    private float endTimer;

    private void Start()
    {
        isEnd = false;
    }

    private void Update()
    {
        if(isEnd)
        {
            endTimer -= Time.deltaTime;
            if(endTimer < 0)
            {
                generator.DestroyEntities();
                changeScene();
            }
        }
    }

    public void EndGame()
    {
        endTimer = 4;
        fader.FadeIn();
        isEnd = true;
    }

    private void changeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
