using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class LevelGenerator : MonoBehaviour
{
    public Transform[] possibleLocations;
    //public Button resetButton, clearButton;
    //public bool isClicked;
    //public Transform playerPositionData;
    //private Vector3 positionData, previousPosition;
    public GameObject exitObject, playerObject, obstacleObject;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    //public GameObject[] spawnedObjects;
    private List<Vector3> occupiedPositions = new List<Vector3>();  //declare a list of Vector3 to store occupied locations
    private List<List<Vector3>> allPositions = new List<List<Vector3>>();
    public NavMeshSurface surface;
    private float timeConsumed = 1200f;
    public int epoch = 0;
    // Start is called before the first frame update
    public class levelData
    {
        public GameObject objectName;
        public Vector3 objectPosition;
        public Vector3 ObjectRotation;
    }
    levelData levelDataVar = new levelData();
    List<levelData> levelDataList = new List<levelData>();
    List<List<levelData>> levelGenerationData = new List<List<levelData>>();
    void Start()
    {
        //resetButton.onClick.AddListener(OnButtonReset);
        occupiedPositions.Clear(); //clear garbage vals in occupiedPositions list if any
        SpawnObject(possibleLocations, exitObject, 1);
        SpawnObject(possibleLocations, playerObject, 1);
        SpawnObject(possibleLocations, obstacleObject, 3);
        spawnedObjects.Add(GameObject.FindGameObjectWithTag("Player"));
        spawnedObjects.Add(GameObject.FindGameObjectWithTag("Finish"));
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            spawnedObjects.Add(item);
        }
        allPositions.Add(occupiedPositions);
        surface.BuildNavMesh();
        CreateTextFile();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("level data list is " + levelGenerationData[0].);

        //resetButton.onClick.AddListener(OnButtonReset);
        /*if (isClicked == true)
        {
            SpawnObject(possibleLocations, exitObject, 1);
            SpawnObject(possibleLocations, playerObject, 1);
            SpawnObject(possibleLocations, obstacleObject, 3);
        }*/
        //if c is pressed delete objects
        if (Input.GetKeyDown("c"))
        {
            ClearPreviouslySpawnedObjects();
        }
        
        //if r is pressed reset level with new config
        if (Input.GetKeyDown("r"))
        {
            
            /*if (GameObject.Find("Exit(Clone)")) //delete this /* to revert
            {
                Destroy(GameObject.Find("Exit(Clone)"));
            }
            //assign random position to positionData vector3 variable from list of possible locations
            positionData = possibleLocations[Random.Range(0, possibleLocations.Length)].position;
            //assign current position to new position variable
            previousPosition = positionData;
            //print the randob position
            Debug.Log("Randob position is " + positionData);
            //instantiate the "Exit" prefab
            Instantiate(exitObject, positionData, Quaternion.identity);
            //assign random position to positionData vector3 variable from list of possible locations
            positionData = possibleLocations[Random.Range(0, possibleLocations.Length)].position;
            Debug.Log("Randob position is " + positionData);
            if (GameObject.Find("Player(Clone)"))
            {
                Destroy(GameObject.Find("Player(Clone)"));
            }
            //instantiate player game object
            if (!GameObject.Find("Player(Clone)") && previousPosition != positionData)
            {
                Instantiate(playerObject, positionData, Quaternion.identity);
            }*/ //delete this 
            SpawnObject(possibleLocations, exitObject, 1);
            SpawnObject(possibleLocations, playerObject, 1);
            SpawnObject(possibleLocations, obstacleObject, 3);
        }

    }
    
    //function to spawn object, takes list of possible locations, object to be spawned & no. of objects as arguments
    public void SpawnObject(Transform[] possiblePositionList, GameObject objectToBeSpawned = null, int numberOfObjectsToBeSpawned = 1)
    {
        Vector3 spawnPosition;  //define new local vector3 var

        for (int i = 0; i < numberOfObjectsToBeSpawned; i++)
        {
            spawnPosition = possiblePositionList[Random.Range(0, possiblePositionList.Length)].position;
            if (!occupiedPositions.Contains(spawnPosition))
            {
                Instantiate(objectToBeSpawned, spawnPosition, Quaternion.identity);
                occupiedPositions.Add(spawnPosition);
                levelDataVar.objectName = objectToBeSpawned;
                levelDataVar.objectPosition = spawnPosition;
                //levelDataVar.ObjectRotation = Vector3(0, 0, 0);
                levelDataList.Add(levelDataVar);
            }
        }
        
        levelGenerationData.Add(levelDataList);
    }
    //function to clear mention objects from level
    public void ClearPreviouslySpawnedObjects()
    {
        //while (GameObject.Find("Exit(Clone)"))
        //{
        //Destroy(GameObject.Find("Exit(Clone)"));

        //}
        /*if (spawnedObjects.Count > 0)
        {
            for (int j = spawnedObjects.Count ; j >= 0; j--)
            {
                
                //DestroyImmediate(spawnedObjects[j - 1], true);
                //spawnedObjects.RemoveAt(spawnedObjects.Count);
                if (GameObject.Find("Exit(Clone)"))
                {
                    Debug.Log("deleted " + spawnedObjects[j - 1] + j);
                    Destroy(GameObject.Find("Exit(Clone)"));
                }
            }
            
        }*/
        //spawnedObjects = (GameObject.FindGameObjectsWithTag("Player"));
        //spawnedObjects = GameObject.FindGameObjectsWithTag("Finish");
        //spawnedObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        
        foreach(GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        //Destroy(GameObject.Find("Exit(Clone)"));
        //Destroy(GameObject.Find("Player(Clone)"));
        //Destroy(GameObject.Find("Obstacle(Clone)"));
        occupiedPositions.Clear();
    }
    //    if (GameObject.Find("Exit"))
    //    {
    //        Destroy(GameObject.Find("Exit"));
    //    }
    //assign random position to positionData vector3 variable from list of possible locations
    //    positionData = possibleLocations[Random.Range(0, possibleLocations.Length)].position;
    //assign current position to new position variable
    //    previousPosition = positionData;
    //print the randob position
    //    Debug.Log("Randob position is " + positionData);
    //instantiate the "Exit" prefab
    //    Instantiate(exitObject, positionData, Quaternion.identity);
    public void OnButtonReset()
    {
        //SceneManager.LoadScene("GeneratorScene");
        Debug.Log("button pressed");
        SpawnObject(possibleLocations, exitObject, 1);
        SpawnObject(possibleLocations, playerObject, 1);
        SpawnObject(possibleLocations, obstacleObject, 3);
    }
    public void OnButtonClear()
    {
        //SceneManager.LoadScene("GeneratorScene");
        Destroy(GameObject.Find("Exit(Clone)"));
        Destroy(GameObject.Find("Player(Clone)"));
        Destroy(GameObject.Find("Obstacle(Clone)"));
        occupiedPositions.Clear();
    }
    void CreateTextFile()
    {
        //path
        Debug.Log("text file created");
        Debug.Log(Application.dataPath.ToString());
        string path = Application.dataPath + "GeneratedText.txt";
        //create file
        Debug.Log("Writing file");
        /*File.WriteAllText("D:/Generated.txt", "File generated at ");
        foreach (GameObject obj in spawnedObjects)
        {
            File.WriteAllText("D:/Generated.txt",obj.ToString() + obj.transform.position.ToString() + obj.transform.rotation.ToString());
        }
        if (!File.Exists(path))
        {
            Debug.Log("Writing file");
            File.WriteAllText(path, "File generated at ");
        }*/
        //TextWriter tw = new StreamWriter
        /*
        foreach(List<levelData> l in levelGenerationData)
        {
            foreach(levelData lData in l)
            {
                File.AppendAllText(path, lData.objectName.ToString() + lData.objectPosition.ToString());
            }
        }*/
        
        using(StreamWriter sw = new StreamWriter("D:/Unity_Projects/Move_It/Move_It/Assets/Scripts/GeneratedData.txt", true))
        {
            sw.WriteLine("******new_level******");
            foreach(GameObject obj in spawnedObjects)
            {
                sw.WriteLine(obj.ToString() + " " + obj.transform.position + " " + obj.transform.rotation);
            }
        }
    }
}
