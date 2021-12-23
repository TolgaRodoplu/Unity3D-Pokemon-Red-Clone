using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public Pokemon current;

    public Pokemon Spawn()
    {
        //Accessing the current route
        string route = gameObject.GetComponent<Player>().area;
        int Rate = Random.Range(1, 101);

        //Selecting a pokemon from csv according to current route 
        string[] line = CSV_Read.ReadCSV(route, Rate, 1);

        //initilize id
        int id = System.Int32.Parse(line[1]);

        //initilize min_lvl for random level
        int min_lvl = System.Int32.Parse(line[2]);

        //initilize max_lvl for random level
        int max_lvl = System.Int32.Parse(line[3]);

        //initilize lvl randomly
        int lvl = Random.Range(min_lvl,max_lvl);
        
        //Get the selected pokemons data from csv
        string[] pokemon_data = CSV_Read.ReadCSV("Pokemon", id, 0);

        //Spawn the pokemon
        current = new Pokemon(pokemon_data, lvl);

        return current;
    }
}
