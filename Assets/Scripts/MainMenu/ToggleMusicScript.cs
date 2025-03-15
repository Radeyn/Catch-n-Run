using UnityEngine;

public class ToggleMusicScript : MonoBehaviour
{
    public AudioSource gameMusic;
    void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        

    }

    public void onValueChanged(bool isOn)
    {
            gameMusic.mute = isOn;
    }
}
