using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class FruitPool : MonoBehaviour
{
    [SerializeField] Fruit[] littleFruitPrefab;

    [SerializeField] Score score;
    [SerializeField] PlayerStatus player;

    public ObjectPool<Fruit> _fruitObjectPool;

    private void Start()
    {
        _fruitObjectPool = new ObjectPool<Fruit>(
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
        Fruit fruit = Instantiate(littleFruitPrefab[index]);
        GameObject fruitObj = fruit.gameObject;
        fruit.SetFruit(this);
        fruit.SetReferences(score);
        fruit.SetPlayer(player);
        fruitObj.SetActive(false);

        return fruit;
    }

    public Fruit GetLittleFruitFromPool()
    {
        return _fruitObjectPool.Get();
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
