using System;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{

    [SerializeField] public ASCIILevelLoader loader;
    
    public GameObject prefabObstacle;
    public GameObject prefabPlayer;
    public GameObject prefabWall;
    public GameObject prefabGoal;
    public GameObject prefabText;

    //the file name
    public string fileName;

    //defines the filepath we are accessing
    string filePath;

    public int currentLevel = 0;




    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
        }
        get
        {
            return currentLevel;
        }
    }

    public float offsetX = -3;
    public float offsetY = -3;

    GameObject levelHolder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        CurrentLevel = 0;
    }


    
    public void LoadLevel()
    {

        if (levelHolder != null)
        {
            Destroy(levelHolder);
        }
        
        levelHolder = new GameObject("levelHolder");
        
        //this accesses the assests
        filePath = Application.dataPath;
        Debug.Log(filePath);


        // string fileContents = File.ReadAllText(filePath + fileName);
        // Debug.Log(fileContents);

        string[] lines = File.ReadAllLines(filePath + fileName.Replace("<num>", currentLevel.ToString()));
        for (int y = 0; y < lines.Length; y++)
        {
            Debug.Log(lines[y]);

            string line = lines[y];
            char[] charArray = line.ToCharArray();

            for (int x = 0; x < charArray.Length; x++)
            {
                char c = charArray[x];

                GameObject newObj = null;

                switch (c)
                {
                    case 'P':
                        newObj = Instantiate<GameObject>(prefabPlayer);
                        break;
                    case 'W':
                        newObj = Instantiate<GameObject>(prefabWall);
                        break;
                    case '*':
                        newObj = Instantiate<GameObject>(prefabObstacle);
                        break;
                    case 'G':
                        newObj = Instantiate<GameObject>(prefabGoal);
                        break;
                    case 'T':
                        newObj = Instantiate<GameObject>(prefabText);
                        break;
                    default:
                        break;
                    
                }

                if (newObj != null)
                {
                    newObj.transform.parent = levelHolder.transform;
                    newObj.transform.position = new Vector3(offsetX + x - offsetX, offsetY + y - offsetY);
                }

            }
        }
    }




    // **this was my desperate attempt to try and run a random level generator via ASCII characters**
    // void AppendStarsToFile()
    // {
    //     string gridString = "";
    //
    //     // Loop through each row of the grid
    //     for (int y = 0; y < levelHeight; y++)
    //     {
    //         string line = "";
    //         
    //         // Loop through each column of the grid (for each line)
    //         for (int x = 0; x < levelWidth; x++)
    //         {
    //             // Randomly decide whether to place a '*' or a space
    //             line += Random.Range(0, 2) == 0 ? ' ' : '*';  // 50% chance to place a '*' or a space
    //         }
    //
    //         gridString += line + "\n";  // Add the line to the grid string with a newline at the end
    //     }
    //
    //     Debug.Log("Generated Grid:\n" + gridString);  // Debugging: check the generated grid string
    //
    //     
    //     WriteGridToFile(gridString);
    // }
    //
    // // Append the grid to the .txt file
    // void WriteGridToFile(string gridString)
    // {
    //     
    //     filePath = Application.dataPath + "/Resources/Levels/Level.txt";  
    //
    //     
    //     Debug.Log("Writing to file: " + filePath);
    //
    //     
    //     File.AppendAllText(filePath, gridString);  
    //
    //  
    //     Debug.Log("Data appended to file.");
    // }

}
