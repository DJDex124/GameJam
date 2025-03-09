using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Game Variables
    public float timer;         //Check if new gem can spawn aka Spawntimer.
    private float timer_;       //teh default constant timer set to what ur timer is at start
    public GameObject Sphere;         //Gem prefab 
    public GameObject[] Spawnpoint;     //The Gameobject for each spawnpoint
    public int ammountOfSpawnpoints;    //the amount of spawnpoints we have in scene
    private int chosenSpawnpoint;        //Random number designation for spawning purposes
    //Player Variables
    public float movementSpeed;         //Players Movement Speed


    public void Start()
    {
        //check if gem is set
        if (!Sphere) //If Gem is not set
            Debug.Log("Warning: Gem is not set in inspector menu");
        //Set timer_ to timer
        timer_ = timer;

    }

    public void Update()
    {
        //check if timer is high than zero, then subtract it
        if (timer > 0)
            timer -= 1 * Time.deltaTime;
        //check if timer is zero, then spwan a new sphere
        if (timer <= 0)
            Spawn();

        //player movement
        if(Input.GetKey(KeyCode.A))
            this.transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);

        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);

    }

    public void Spawn()
    {
        chosenSpawnpoint = Random.Range(0, ammountOfSpawnpoints);
        Instantiate(Sphere.transform, Spawnpoint[chosenSpawnpoint].transform.position, Quaternion.identity);
        timer = timer_;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Gem")
        {
            Debug.Log("Gem");
        }
    }



}



