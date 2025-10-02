using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    [SerializeField]private ResetGameScript resetGameScript;
    
    public void OnClick()
    {
        resetGameScript.ResetGame();
    }
}
