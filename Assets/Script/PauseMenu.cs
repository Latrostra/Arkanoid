using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    void OnPause(InputValue value)
    { 
        if (!pauseMenu.active) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            return;
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
