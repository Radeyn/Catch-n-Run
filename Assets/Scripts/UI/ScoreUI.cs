using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private float displayedScore;
    [SerializeField] float animationSpeed = 1.5f;

    private void Start()
    {
        displayedScore = score.score;
    }

    private void Update()
    {
        displayedScore = Mathf.Lerp(displayedScore, score.score, animationSpeed * Time.deltaTime);

        scoreText.text = displayedScore.ToString("0");
        totalScoreText.text = score.score.ToString();
    }
}