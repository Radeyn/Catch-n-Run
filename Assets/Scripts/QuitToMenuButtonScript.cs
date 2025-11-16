using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenuButtonScript : MonoBehaviour
{
    private ToggleMusicScript toggleMusicScript;

    private void Start()
    {
        toggleMusicScript = FindAnyObjectByType<ToggleMusicScript>();
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
