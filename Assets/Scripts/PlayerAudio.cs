using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    private Player player;


    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (player.IsMoving())
        {
            if (!footstepsSound.isPlaying) 
            {
                footstepsSound.Play();
            }
        }else
        {
            footstepsSound.Stop();

        }
    }
}
