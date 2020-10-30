using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverModal : MonoBehaviour
{
    [SerializeField] GameObject content;

    private void Awake()
    {
        Game.Instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver(object sender, System.EventArgs e)
    {
        content.SetActive(true);
    }

    public void OnPlayAgainClicked()
    {
        Game.Instance.Restart();
    }
}
