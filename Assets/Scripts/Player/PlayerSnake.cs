using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerSnake : MonoBehaviour
{
    List<Vector3> segmentsPosition = new List<Vector3>();
    List<GameObject> segmentsObject = new List<GameObject>();
    [SerializeField] GameObject segmentPrefab;
    public int maxSegments = 6;
    [SerializeField]float offset;

    [SerializeField] float moveTimerMax = 0.5f;
    float moveTimer;
    void Update()
    {
        UpdateSnake();
    }
    void UpdateSnake()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveTimerMax)
        {
            moveTimer = 0;

            Vector3 spawnPos = Offset(transform);

            segmentsPosition.Add(spawnPos);
            GameObject newSegment = Instantiate(segmentPrefab, segmentsPosition[segmentsPosition.Count - 1] , Quaternion.identity);
            segmentsObject.Add(newSegment);
            newSegment.name = "segment " + segmentsObject.IndexOf(newSegment);
            segmentsPosition[segmentsPosition.Count - 1] = segmentsObject[segmentsObject.Count - 1].transform.forward * offset;
        }
        if (segmentsPosition.Count > maxSegments)
        {
            Destroy(segmentsObject[0]);
            segmentsPosition.RemoveAt(0);
            segmentsObject.RemoveAt(0);
        }
    }
    Vector3 Offset(Transform relativeToTransform)
    {
        float offsetAmount = offset;
        Vector3 finalOffset = Vector3.zero;
        Vector3 forward = relativeToTransform.forward;
        if(forward == Vector3.up || forward == -Vector3.up)
        {
            if (forward == -Vector3.up) offsetAmount = -offsetAmount;
            finalOffset = relativeToTransform.position - new Vector3(0, offsetAmount, 0);
        }
        if(forward == Vector3.right || forward == -Vector3.right)
        {
            if (forward == -Vector3.right) offsetAmount = -offsetAmount;
            finalOffset = relativeToTransform.position - new Vector3(offsetAmount, 0, 0);
        }
        if(forward == Vector3.forward || forward == -Vector3.forward)
        {
            if (forward == -Vector3.forward) offsetAmount = -offsetAmount;
            finalOffset = relativeToTransform.position - new Vector3(0, 0, offsetAmount);
        }
        return finalOffset;
    }
}
