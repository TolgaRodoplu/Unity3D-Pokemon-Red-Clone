using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    Pokemon Enemy_Pokemon;
    Pokemon Player_Pokemon;
    public Transform Enemy_Pos;
    public Transform Player_Pos;
    public void Initiate(Pokemon enemy)
    {
        Enemy_Pokemon = enemy;
        Player_Pokemon = gameObject.GetComponent<Player>().team[0];

        //
        string prefab_path = Enemy_Pokemon.id.ToString() + '/' + Enemy_Pokemon.id.ToString();
        Enemy_Pokemon.pokemon_object = Instantiate(Resources.Load("Pokemon_Models/" + prefab_path) as GameObject);

        //
        prefab_path = Player_Pokemon.id.ToString() + '/' + Player_Pokemon.id.ToString();
        Player_Pokemon.pokemon_object = Instantiate(Resources.Load("Pokemon_Models/" + prefab_path) as GameObject);

        //
        Enemy_Pokemon.pokemon_object.transform.position = Enemy_Pos.position;
        Player_Pokemon.pokemon_object.transform.position = Player_Pos.position;
        Player_Pokemon.pokemon_object.transform.rotation = Quaternion.Euler(0,180,0);


    }
}
