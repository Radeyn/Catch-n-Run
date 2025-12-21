using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class FruitPool : MonoBehaviour
{
    [SerializeField] Fruit[] littleFruitPrefab;
   // [SerializeField] Transform[] spawnPoints;

    [SerializeField] Score score;
    [SerializeField] PlayerStatus player;

    public ObjectPool<Fruit> _littleFruitObjectPool;

    private void Start()
    {
        _littleFruitObjectPool = new ObjectPool<Fruit>(
            CreateLittleFruit,
            EnableFruit,
            DisableFruit,
            DestroyFruit,
            true,
            50,
            100
            );
    }

    private Fruit CreateLittleFruit()
    {
        int index = Random.Range(0, littleFruitPrefab.Length);
        Fruit littleFruit = Instantiate(littleFruitPrefab[index]);
        GameObject littleFruitObj = littleFruit.gameObject;
        littleFruit.SetFruit(this);
        littleFruit.SetReferences(score);
        littleFruit.SetPlayer(player);
        littleFruitObj.SetActive(false);

        return littleFruit;
    }

    public Fruit GetLittleFruitFromPool()
    {
        return _littleFruitObjectPool.Get();
    }
    public void EnableFruit(Fruit fruit)
    {
        float x = Random.Range(-14f, 14f);
        float y = 15f;
        fruit.transform.position = new Vector2(x, y);
        fruit.gameObject.SetActive(true);
    }

    private void DisableFruit(Fruit fruit)
    {
        fruit.gameObject.SetActive(false);
    }

    private void DestroyFruit(Fruit fruit)
    {
        Destroy(fruit.gameObject);
    }

  
}
