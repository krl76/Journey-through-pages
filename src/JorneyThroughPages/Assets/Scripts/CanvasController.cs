using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private string _nameOfGameScene;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MapAnims");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(_nameOfGameScene);
    }
}
