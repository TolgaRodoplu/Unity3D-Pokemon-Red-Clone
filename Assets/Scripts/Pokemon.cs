using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pokemon 
{
    public int id;
    public int level;
    public int next_evolution_lvl;
    public string species;
    public int type1_id;
    public string type1_name;
    public int type2_id;
    public string type2_name;
    public int[,] stats;
    /*stats matrix
    |||||||||||||||0-HP||1-Attack||2-Defanse||3-Sp.Atk||4-Sp.Def||5-Speed||
    ||0-Base stat||    ||        ||         ||        ||        ||       ||
    ||   1-IV    ||    ||        ||         ||        ||        ||       ||
    ||   2-EV    ||    ||        ||         ||        ||        ||       ||
    ||  3-Total  ||    ||        ||         ||        ||        ||       ||
    */
    //Move [] moves;
    public int [] ev_yield;
    public string pokedex_entry;
    public int evolve_level;//if null this pokemon will be evolved by other means
    //Nature ?????????????????
    public int current_hp; // When full current_hp = stats[3,0]
    public string name;  //if null => name = species
    public GameObject pokemon_object;

    
    void Calculate_Stats()
    {
        //Calculate HP
        stats[3, 0] = Calculate_Core(0) + level + 10;

        //Calculate Other Stats
        for (int i = 1; i < 6; i++)
            stats[3, i] = (Calculate_Core(i) + 5);// * Nature
    }

    int Calculate_Core(int stat)
    {
        return ((2 * stats[0, stat] + stats[1, stat] + (stats[2, stat] / 4)) / 100);
    }

    //Constructer for Wild_Pokemon
    public Pokemon(string[] line, int lvl)
    {
        string[] pokemon_data = line;

        stats = new int[6,6];
        ev_yield = new int[6];

        //initilize level
        level = lvl;
        Debug.Log(level);

        //initilize id
        id = System.Int32.Parse(pokemon_data[0]);
        Debug.Log(id);

        //initilize next_evolution_lvl
        next_evolution_lvl = System.Int32.Parse(pokemon_data[1]);
        Debug.Log(next_evolution_lvl);

        //initilize species name
        species = pokemon_data[2];
        Debug.Log(species);

        //initilize type1_id and name
        type1_id = System.Int32.Parse(pokemon_data[3]);
        type1_name = pokemon_data[4];
        Debug.Log(type1_id + type1_name);

        //initilize type2_id and name
        type2_id = System.Int32.Parse(pokemon_data[5]);
        type2_name = pokemon_data[6];
        Debug.Log(type2_id + type2_name);

        //initilize Base Stats
        for (int i = 0; i < 6; i++)
        {
            stats[0, i] = System.Int32.Parse(pokemon_data[i + 7]);
            Debug.Log(stats[0, i]);
        }
            

        //initilize IV values
        for (int i = 0; i < 6; i++)
        {
            stats[1, i] = Random.Range(0, 32);
            Debug.Log(stats[1, i]);
        }
            

        //initilize EV values
        for (int i = 0; i < 6; i++)
        {
            stats[2, i] = 0;
            Debug.Log(stats[2, i]);
        }
            

        //initilize EV yields
        for (int i = 0; i < 6; i++)
        {
            ev_yield[i] = System.Int32.Parse(pokemon_data[i + 13]);
            Debug.Log(ev_yield[i]);
        }

        //initilize evolution level
        evolve_level = System.Int32.Parse(pokemon_data[19]);
        Debug.Log(evolve_level);

        /*
        //initilize pokedex entry
        pokedex_entry = pokemon_data[19];
        Debug.Log(pokedex_entry);

        //initilize calculate the total stats
        Calculate_Stats();
        */
    }

    void Level_Up()
    {
        level++;
        Calculate_Stats();
    }

    
}

