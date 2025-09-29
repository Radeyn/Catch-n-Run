using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]private GameObject gameManager;
    private Score score;
    private int _previousScore;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if (score.currentScore == _previousScore) return;
        _previousScore = score.currentScore;
        scoreText.text = _previousScore.ToString();

        totalScoreText.text = score.currentScore.ToString();
    }
    private void GetReferences()
    {
        score = gameManager.GetComponent<Score>();
    }
}
