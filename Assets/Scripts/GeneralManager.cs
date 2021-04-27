using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    private void Start()
    {
        ShowMenu();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("AbsoluteChonker");
    }

    public void ShowCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
