using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Maneger : MonoBehaviour
{
    private float Spawn_Rate = 50;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag.Equals("Bush"))
        {
            //Generate a random number and based on that execute an encounter
            int spawn = Random.Range(1, 101);

            if (spawn <= Spawn_Rate)
            {
                Pokemon current = gameObject.GetComponent<Generate>().Spawn();
                gameObject.GetComponent<Fight>().Initiate(current);
                Debug.Log("Something Appeared");
                
            }
        }
            
    }

   
    
}
