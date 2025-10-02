using UnityEngine;

public class GameMusicScript : MonoBehaviour
{
    private AudioSource _gameMusic;

    public void Update()
    {
        _gameMusic.Play();
    }
}
