using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //author:   alamurit
    //date: 18/01/2022
    //this scripts enables movement of the player
    private Transform playerTransform, exitTransform;
    private Text movesNumber;
    private int moves = 0;
    private NavMeshAgent navMeshAgent;
    private LevelGenerator levelGenerator;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("game has started!");
        //get player's "Transform" component and assign it to "playerTransform" variable
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        movesNumber = GameObject.Find("Moves_No").GetComponent<Text>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        exitTransform = GameObject.Find("Exit(Clone)").GetComponent<Transform>();
        levelGenerator = GameObject.Find("Floor").GetComponent<LevelGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        movesNumber.text = ("number of moves" + moves);
        //check weather user pressed "W" or not and if pressed move player forward!
        if (Input.GetKeyDown("w"))
        {
            //move player forward
            playerTransform.position += new Vector3(2f, 0, 0);
            moves += 1;
        }
        //check weather user pressed "S" or not and if pressed move player backward!
        if (Input.GetKeyDown("s"))
        {
            //move player backward
            playerTransform.position += new Vector3(-2f, 0, 0);
            moves += 1;
        }
        //check weather user pressed "D" or not and if pressed move player right!
        if (Input.GetKeyDown("d"))
        {
            //move player right
            playerTransform.position += new Vector3(0, 0, -2f);
            moves += 1;
        }
        //check weather user pressed "A" or not and if pressed move player left!
        if (Input.GetKeyDown("a"))
        {
            //move player left
            playerTransform.position += new Vector3(0, 0, 2f);
            moves += 1;
        }
        navMeshAgent.speed = 1f;  //change this to modify player movement speed
        //set destination for navMeshAgent
        navMeshAgent.SetDestination(exitTransform.position);
    }
    //when player overlaps a trigger
    private void OnTriggerEnter(Collider other)
    {
        //check weather the tag of trigger is "Finish" or not
        if (other.tag == "Finish")
        {
            //if(SceneManager.GetActiveScene().name == "LevelOne")
            //{
            //    Debug.Log("finished");
            //    SceneManager.LoadScene("LevelTwo");
            //}
            //else
            //{
            //    Debug.Log("finished game");
            //}
            //SceneManager.LoadScene("LevelTwo");
            //give "finished" message in console
            //Debug.Log("finished");
            //to do:
            //create new level with name "LevelTwo"
            //add progression system to next level ie "LevelTwo"
            SceneManager.LoadScene("GeneratorScene");
        }
    }
}
