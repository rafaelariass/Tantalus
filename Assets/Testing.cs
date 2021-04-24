using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    public Button start, quit;

    
    void Start()
    {
        start.onClick.AddListener(LoadScene);
        quit.onClick.AddListener(QuitGame);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Greyboxing");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
