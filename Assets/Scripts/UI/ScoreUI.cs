using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]private GameObject gameManager;
    private Score _score;
    private int _previousScore;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if (_score.currentScore == _previousScore) return;
        _previousScore = _score.currentScore;
        scoreText.text = _previousScore.ToString();

        totalScoreText.text = _score.currentScore.ToString();
    }
    private void GetReferences()
    {
        _score = gameManager.GetComponent<Score>();
    }
}
