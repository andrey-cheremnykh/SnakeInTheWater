using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGenerationSettings : MonoBehaviour
{
    [SerializeField] TMP_InputField depthInput, heightInput, widthInput, appleCountInput;
    [SerializeField] GameObject objectSpawningPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    int GetValueFromInputField(TMP_InputField inputField)
    {
        string inputText = inputField.text;
        int inputValue = 0;
        if (!string.IsNullOrWhiteSpace(inputText))
        {
            try
            {
                inputValue = int.Parse(inputText);
            }
            catch (System.FormatException)
            {
                print("Please input an integer");
            }

        }
        return inputValue;
    }
    public void GenerateLevel()
    {
        int levelWidth = GetValueFromInputField(widthInput) / 2;
        int levelHeight = GetValueFromInputField(heightInput) / 2;
        int levelDepth = GetValueFromInputField(depthInput) / 2;
        int appleCount = GetValueFromInputField(appleCountInput);
        if (levelWidth == 0 || levelHeight == 0 || levelDepth == 0 || appleCount == 0)
        {
            print("Invalid input");
            return;
        }
        GameObject objectSpawner = Instantiate(objectSpawningPrefab, Vector3.zero, Quaternion.identity);
        LevelObjectSpawning objectSpawning = objectSpawner.GetComponent<LevelObjectSpawning>();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(objectSpawner);
        FindObjectOfType<UI>().GoToScene(1);


        objectSpawning.maxX = levelWidth;
        objectSpawning.maxY = levelHeight;
        objectSpawning.maxZ = levelDepth;
        objectSpawning.minX = -levelWidth;
        objectSpawning.minY = -levelHeight;
        objectSpawning.minZ = -levelDepth;

        objectSpawning.appleCount = appleCount;
        objectSpawning.GenerateLevelBorders();

        GameObject player = Instantiate(objectSpawning.playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<PointToApple>().levelSpawnManager = objectSpawning.gameObject;
    }
}
