//using System;
//using Unity.VisualScripting;
//using UnityEngine;

//public class TestPrefab : MonoBehaviour, IPoolable
//{
//    private GenericObjectPool<TestPrefab> pool;

//    public void SetPool(GenericObjectPool<TestPrefab> poolRef)
//    {
//        pool = poolRef;
//    }

//    public void OnSpawned()
//    {
//        // spawn olduğunda
//    }

//    public void OnDespawned()
//    {
//        // reset logic
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.collider.CompareTag("Floor"))
//        {
//            pool.Release(this);
//        }
//    }
//}