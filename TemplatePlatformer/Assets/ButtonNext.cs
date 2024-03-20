using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void startmenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
