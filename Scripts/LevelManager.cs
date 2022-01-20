using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Load specified scenes when their functions are used
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TableOfContents()
    {
        SceneManager.LoadScene(2);
    }

    public void TutrialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void AcknowledgementButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Ch1()
    {
        SceneManager.LoadScene("Ch1");
    }

    public void Ch2()
    {
        SceneManager.LoadScene("Ch2");
    }

    public void Ch3()
    {
        SceneManager.LoadScene("Ch3");
    }

    public void Ch4()
    {
        SceneManager.LoadScene("Ch4");
    }

    public void Ch5()
    {
        SceneManager.LoadScene("Ch5");
    }
}
