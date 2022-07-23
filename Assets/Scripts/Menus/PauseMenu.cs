using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool menuIsOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuIsOpen)
            {
                pauseMenu.SetActive(false);
                menuIsOpen = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                menuIsOpen = true;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
