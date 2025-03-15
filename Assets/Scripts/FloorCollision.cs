using UnityEngine;

public class FloorCollision : MonoBehaviour
{


    private Rigidbody2D rb;
    public Transform[] objectPrefabs;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit") || collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);
        }
    }

}
