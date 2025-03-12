using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTransform : MonoBehaviour
{
    public Player player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        float score = player.score;
       

        switch (score) 
        {
            case 5:

                UpdatePlayer(22.5f, 8.25f);
                break;

            case 10:
                UpdatePlayer(20f, 8.50f);
                break;

            case 15:
                UpdatePlayer(17.5f, 8.75f);
                break;

            case 20:
                UpdatePlayer(15f, 9f);
                break;

            case 25:
                UpdatePlayer(12.5f, 9.25f);
                break;

            case 30:
                UpdatePlayer(10f, 9.50f);
                break;

        }

    }

    private void UpdatePlayer(float speed, float scaleX)
    {
        player.moveSpeed = speed;
        player.transform.localScale = new Vector3(scaleX, 8, 8);
    }



}
