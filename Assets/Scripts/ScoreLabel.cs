using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] Text label;

    int m_Score;
    public int Score
    {
        get { return m_Score; }
        set { m_Score = value; label.text = value.ToString(); }
    }

    private void Awake()
    {
        Score = 0;
        Collectable.OnCollect += Collectable_OnCollect;
    }

    private void Collectable_OnCollect(object sender, Collectable.OnCollectArgs e)
    {
        Score++;
    }
}
