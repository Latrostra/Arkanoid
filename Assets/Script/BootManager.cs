using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    public void LoadScene(int id) {
        SceneManager.LoadScene(id);
    }

    public void Exit() {
        Application.Quit();
    }
}
