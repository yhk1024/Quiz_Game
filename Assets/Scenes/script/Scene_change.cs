using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_change : MonoBehaviour
{

    public void Main()
    {
        SceneManager.LoadScene("Main");
    }

    public void Explain()
    {
        SceneManager.LoadScene("Explain");
    }

    public void Quiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
