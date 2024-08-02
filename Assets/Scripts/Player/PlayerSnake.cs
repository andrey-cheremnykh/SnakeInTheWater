using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerSnake : MonoBehaviour
{
    [SerializeField] GameObject segmentPrefab;
    public int segmentCount;
    List<Vector3> segmentsPosition = new List<Vector3>();
    List<GameObject> segmentsObject = new List<GameObject>();
    float moveTimer;
    [SerializeField] float moveTimerMax = 0.5f;
    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        UpdateSnake();
    }
    void UpdateSnake()
    {
        moveTimer += Time.deltaTime;
        /*if (transform.position.x == Mathf.FloorToInt(transform.position.x)
            && transform.position.y == Mathf.FloorToInt(transform.position.y)
            && transform.position.z == Mathf.FloorToInt(transform.position.z))*/
        if (moveTimer - moveTimerMax == moveTimerMax)
        {

            segmentsPosition.Add(transform.position);
            GameObject newSegment = Instantiate(segmentPrefab, segmentsPosition[segmentsPosition.Count - 1], Quaternion.identity);
            segmentsObject.Add(newSegment);
            newSegment.name = "segment " + segmentsObject.IndexOf(newSegment);

        }
        if (segmentsPosition.Count > segmentCount)
        {
            Destroy(segmentsObject[segmentsObject.Count - 1]);
            print(segmentsObject[segmentsObject.Count - 1]);
            segmentsPosition.RemoveAt(segmentsPosition.Count - 1);
            segmentsObject.RemoveAt(segmentsObject.Count - 1);
        }
    }
}
