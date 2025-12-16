using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> objectPool = new List<GameObject>(); // List is created
    [SerializeField] int objectPoolSize; // How big the list is gonna be
    [SerializeField] private List<GameObject> objectPrefabs = new List<GameObject>();
    
    int activeObjCount = 0;
    int inactiveObjCount = 0;
    void Awake()
    {
        for (int i = 0; i < objectPoolSize; i++) 
        {
            
            int randomIndex = Random.Range(0, objectPrefabs.Count);
            
            GameObject newObject = Instantiate(objectPrefabs[randomIndex]);
            newObject.SetActive(false);
            objectPool.Add(newObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CountObjects();
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        
        return null;
    }

    public void CountObjects()
    {
        activeObjCount = 0;
        inactiveObjCount = 0;
        
        foreach (var obj in objectPool)
        {
            if (obj.activeInHierarchy)
            {
                activeObjCount++;
            }
            else
            {
                inactiveObjCount++;
            }
        }
        
        Debug.Log("Inactive Count " + inactiveObjCount);
        Debug.Log("Active Count " + activeObjCount);
        Debug.Log("Sum of Objects " + (activeObjCount + inactiveObjCount));
    }
}
