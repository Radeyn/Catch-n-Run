using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    private ResetGameScript resetGameScript;
    void Start()
    {
        resetGameScript = FindAnyObjectByType<ResetGameScript>();
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        resetGameScript.ResetGame();
        

    }
}
