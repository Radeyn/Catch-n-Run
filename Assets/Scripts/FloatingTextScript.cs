using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatingTextScript : MonoBehaviour
{
    [SerializeField] float destroyTime = 3f;
    private Vector2 Offset = new Vector2(0f, 2f);
    private Vector2 RandomizeIntensity = new Vector2(0.5f, 0f);

    private void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.position = new Vector2(transform.position.x + Offset.x, transform.position.y + Offset.y);
    }
}

