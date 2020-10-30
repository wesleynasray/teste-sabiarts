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

    #region Event Subscription
    private void Awake()
    {
        KillArea.OnKill += KillArea_OnKill;
    }

    private void OnDestroy()
    {
        KillArea.OnKill -= (s, a) => GameOver();
    }
    #endregion

    #region Event Handlers
    private void KillArea_OnKill(object sender, EventArgs e)
    {
        GameOver();
    }
    #endregion

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke(this, null);
    }
}
