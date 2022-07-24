using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuContainer;
    public GameObject helpContainer;
    
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeHelpContainer(bool state)
    {
        mainMenuContainer.SetActive(!state);
        helpContainer.SetActive(state);
    }
}
