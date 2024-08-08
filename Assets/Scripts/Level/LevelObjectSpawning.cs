using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectSpawning : MonoBehaviour
{
    public int appleCount = 3;
    public int minX, minY, minZ;
    public int maxX, maxY, maxZ;
    public GameObject playerPrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] Mesh borderMesh;
    [SerializeField] Material borderMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateApples();  
    }
    void GenerateApples()
    {
        int currentAppleCount = GameObject.FindGameObjectsWithTag("Apple").Length / 2;
        //the int above represents double the current amount of apples, so we divide it by 2
        if(currentAppleCount < appleCount)
        {
            int spawnX = Random.Range(minX, maxX);
            int spawnY = Random.Range(minY, maxY);
            int spawnZ = Random.Range(minZ, maxZ);
            Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);
            GameObject newApple = Instantiate(applePrefab, spawnPos, Quaternion.identity);
            newApple.transform.parent = null;
        }
    }
    public void GenerateLevelBorders()
    {
        int xScale = maxX * 2;
        int yScale = maxY * 2;
        int zScale = maxZ * 2;

        GameObject topBorder = new GameObject("Top Border");
        topBorder.transform.localScale = new Vector3(xScale, 1, zScale);
        topBorder.transform.position = new Vector3(0, maxY, 0);

        GameObject bottomBorder = Instantiate(topBorder, new Vector3(0, minY, 0), Quaternion.identity);
        bottomBorder.name = "Bottom Border";

        GameObject rightBorder = new GameObject("Right Border");
        rightBorder.transform.localScale = new Vector3(1, yScale, zScale);
        rightBorder.transform.position = new Vector3(maxX, 0, 0);

        GameObject leftBorder = Instantiate(rightBorder, new Vector3(minX, 0, 0), Quaternion.identity);
        leftBorder.name = "Left Border";

        GameObject frontBorder = new GameObject("Front Border");
        frontBorder.transform.localScale = new Vector3(xScale, yScale, 1);
        frontBorder.transform.position = new Vector3(0, 0, maxZ);

        GameObject backBorder = Instantiate(frontBorder, new Vector3(0, 0, minZ), Quaternion.identity);
        backBorder.name = "Back Border";

        GameObject[] borders = {frontBorder, backBorder, rightBorder, leftBorder, topBorder, bottomBorder};

        for (int i = 0; i < 6; i++)
        {
            borders[i].AddComponent<MeshFilter>().mesh = borderMesh;
            borders[i].AddComponent<MeshRenderer>().material = borderMaterial;
            borders[i].tag = "Obstacle";
            borders[i].AddComponent<BoxCollider>();
        }
    }
}
