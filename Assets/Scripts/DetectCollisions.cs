using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;
    private bool Done;

    //Particles
    public ParticleSystem explosionSystem;

    void Start()
    {
        gameManagerObject =  GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {

        //if (other.gameObject.tag == "Player")
        //{
        if (Done)
            return;

            Done = true;
            explosionSystem.Play();
            gameManager.RocketsCollected();
            Debug.Log("This should explode " + explosionSystem.name);
            //gameObject.SetActive(false);

            Destroy(gameObject, 0.5f);
            //Destroy(gameObject);
        //}
        //else
        //{
            Debug.Log("I'm returning: " + other.gameObject.tag);
        //}

    }
}