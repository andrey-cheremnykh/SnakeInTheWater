using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PointToApple : MonoBehaviour
{
    [SerializeField] GameObject pointerPrefab;
    [SerializeField] GameObject levelSpawnManager;
    [SerializeField] float offset;
    GameObject[] pointers;
    TMP_Text distanceText;
    LevelObjectSpawning objectSpawning; 

    // Start is called before the first frame update
    void Start()
    {
        objectSpawning = levelSpawnManager.GetComponent<LevelObjectSpawning>();
        SpawnPointers();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePointers();
    }
    void SpawnPointers()
    {
        Array.Resize(ref pointers, objectSpawning.appleCount);
        for (int i = 0; i < objectSpawning.appleCount; i++)
        {
            GameObject newPointer = Instantiate(pointerPrefab, Vector3.forward * offset, Quaternion.identity);
            pointers[i] = newPointer;
            newPointer.transform.parent = gameObject.transform;
        }
    }
    void RotatePointers()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        List<GameObject> availableApples = new List<GameObject>(apples);
        for (int i = 0; i < apples.Length; i++)
        {
            int appleToLookAt = UnityEngine.Random.Range(0, availableApples.Count);
            pointers[i].transform.LookAt(availableApples[appleToLookAt].transform);

            distanceText = pointers[i].transform.GetChild(1).GetComponent<TMP_Text>();
            distanceText.transform.LookAt(transform);
            distanceText.text = Mathf.FloorToInt(Vector3.Distance(pointers[i].transform.position,
                availableApples[appleToLookAt].transform.position)).ToString() + 'm';

            availableApples.RemoveAt(appleToLookAt);
        }
    }
}
