using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
    public Transform[] possibleLocations;
    //public Button resetButton, clearButton;
    //public bool isClicked;
    //public Transform playerPositionData;
    //private Vector3 positionData, previousPosition;
    public GameObject exitObject, playerObject, obstacleObject;
    private List<Vector3> occupiedPositions = new List<Vector3>();  //declare a list of Vector3 to store occupied locations
    //private NavMeshAgent
    // Start is called before the first frame update
    void Start()
    {
        //resetButton.onClick.AddListener(OnButtonReset);
        occupiedPositions.Clear(); //clear garbage vals in occupiedPositions list if any
        SpawnObject(possibleLocations, exitObject, 1);
        SpawnObject(possibleLocations, playerObject, 1);
        SpawnObject(possibleLocations, obstacleObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
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
    void SpawnObject(Transform[] possiblePositionList, GameObject objectToBeSpawned = null, int numberOfObjectsToBeSpawned = 1)
    {
        Vector3 spawnPosition;  //define new local vector3 var

        for (int i = 0; i < numberOfObjectsToBeSpawned; i++)
        {
            spawnPosition = possiblePositionList[Random.Range(0, possiblePositionList.Length)].position;
            if (!occupiedPositions.Contains(spawnPosition))
            {
                Instantiate(objectToBeSpawned, spawnPosition, Quaternion.identity);
                occupiedPositions.Add(spawnPosition);
            }
        }
    }
    //function to clear mention objects from level
    void ClearPreviouslySpawnedObjects()
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
        Destroy(GameObject.Find("Exit(Clone)"));
        Destroy(GameObject.Find("Player(Clone)"));
        Destroy(GameObject.Find("Obstacle(Clone)"));
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
        SpawnObject(possibleLocations, exitObject, 1);
        SpawnObject(possibleLocations, playerObject, 1);
        SpawnObject(possibleLocations, obstacleObject, 3);
    }
}
