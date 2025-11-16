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
        if (_score.score == _previousScore) return;
        _previousScore = _score.score;
        scoreText.text = _previousScore.ToString();

        totalScoreText.text = _score.score.ToString();
    }
    private void GetReferences()
    {
        _score = gameManager.GetComponent<Score>();
    }
}
