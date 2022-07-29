using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
            //ScoreManager.instance.AddPoint();
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

 

        // Add to the player's score
       // GameManager.inst.IncrementScore();

        // Destroy this coin object
        Destroy(gameObject);
    }


    private void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime, 0, 0);
    }
}
