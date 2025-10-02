using UnityEngine;

public class FloorCollision : MonoBehaviour
{


    public Transform[] objectPrefabs;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit") || collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(collision.gameObject);
        }
    }

}
