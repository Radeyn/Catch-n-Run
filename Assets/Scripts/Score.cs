using UnityEngine;

public class Score : MonoBehaviour
{
    private readonly int _score = 0;
    public int currentScore;

    private void Start()
    {
        currentScore = _score;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }
}
