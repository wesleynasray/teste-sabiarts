using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    #region Singleton
    static Game m_Instance;
    public static Game Instance
    {
        get 
        { 
            if (m_Instance == null)
                m_Instance = GameObject.FindObjectOfType<Game>();

            return m_Instance;
        }
    }
    #endregion

    #region Events
    public event EventHandler OnGameOver;
    #endregion

    private void Awake()
    {
        KillArea.OnKill += (s,a) => GameOver();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke(this, null);
    }
}
