using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //author:   alamurit
    //date: 18/01/2022
    //this scripts enables movement of the player
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        //get player's "Transform" component and assign it to "playerTransform" variable
        playerTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //check weather user pressed "W" or not and if pressed move player forward!
        if (Input.GetKeyDown("w"))
        {
            //move player forward
            playerTransform.position += new Vector3(2f, 0, 0);
        }
        //check weather user pressed "S" or not and if pressed move player backward!
        if (Input.GetKeyDown("s"))
        {
            //move player backward
            playerTransform.position += new Vector3(-2f, 0, 0);
        }
        //check weather user pressed "D" or not and if pressed move player right!
        if (Input.GetKeyDown("d"))
        {
            //move player right
            playerTransform.position += new Vector3(0, 0, -2f);
        }
        //check weather user pressed "A" or not and if pressed move player left!
        if (Input.GetKeyDown("a"))
        {
            //move player left
            playerTransform.position += new Vector3(0, 0, 2f);
        }
    }
    //when player overlaps a trigger
    private void OnTriggerEnter(Collider other)
    {
        //check weather the tag of trigger is "Finish" or not
        if (other.tag == "Finish")
        {
            //give "finished" message in console
            Debug.Log("finished");
            //to do:
            //create new level with name "LevelTwo"
            //add progression system to next level ie "LevelTwo"
        }
    }
}
