using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    private ResetGameScript resetGameScript;
    private ToggleMusicScript toggleMusicScript;

    private void Start()
    {
        toggleMusicScript = FindAnyObjectByType<ToggleMusicScript>();
        resetGameScript = FindAnyObjectByType<ResetGameScript>();
    }
    public void OnClick()
    {
        SceneManager.LoadScene("MainMenuScene");

        if (toggleMusicScript.gameMusic != null)
        {
            Object.Destroy(toggleMusicScript.gameMusic.gameObject);
        }

    }
}
