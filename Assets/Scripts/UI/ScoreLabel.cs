using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] Text counter;

    int m_Score;
    public int Score
    {
        get { return m_Score; }
        set { m_Score = value; counter.text = value.ToString(); }
    }

    #region Event Subscription
    private void Awake()
    {
        Score = 0;
        Collectable.OnCollect += Collectable_OnCollect;
    }

    private void OnDestroy()
    {
        Collectable.OnCollect -= Collectable_OnCollect;
    }
    #endregion

    private void Collectable_OnCollect(object sender, Collectable.OnCollectArgs e)
    {
        Score++;
    }
}
