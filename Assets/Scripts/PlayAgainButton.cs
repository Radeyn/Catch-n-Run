using System;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    private ResetGameScript resetGameScript;

    private void Start()
    {
        resetGameScript  = FindAnyObjectByType<ResetGameScript>();
    }

    public void OnClick()
    {
        resetGameScript.ResetGame();
    }
}
