using UnityEngine;

public class GameMusicScript : MonoBehaviour
{
    private AudioSource gameMusic;
    void Start()
    {

        
    }

    public void Update()
    {
        gameMusic.Play();
    }
}
