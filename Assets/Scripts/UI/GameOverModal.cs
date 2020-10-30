using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverModal : MonoBehaviour
{
    [SerializeField] GameObject content;

    #region Event Subscription
    private void Awake()
    {
        Game.Instance.OnGameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        Game.Instance.OnGameOver -= OnGameOver;
    }
    #endregion

    private void OnGameOver(object sender, System.EventArgs e)
    {
        content.SetActive(true);
    }

    public void OnPlayAgainClicked()
    {
        Game.Instance.Restart();
    }
}
