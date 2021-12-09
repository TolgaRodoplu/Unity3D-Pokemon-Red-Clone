using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pokemon 
{
    int id;
    int next_evolution_lvl;
    string species;
    int type1_id;
    string type1_name;
    int type2_id;//Can be null
    string type2_name;//Can be null
    int[,] stats;
    /*stats matrix
    |||||||||||||||0-HP||1-Attack||2-Defanse||3-Sp.Atk||4-Sp.Def||5-Speed||
    ||0-Base stat||    ||        ||         ||        ||        ||       ||
    ||   1-IV    ||    ||        ||         ||        ||        ||       ||
    ||   2-EV    ||    ||        ||         ||        ||        ||       ||
    ||  3-Total  ||    ||        ||         ||        ||        ||       ||
    */
    //Move [] moves;
    int[] ev_yield;
    string pokedex_entry;

    int level;
    int evolve_level;//if null this pokemon will be evolved by other means
    bool isShiny;
    //Nature ?????????????????
    int current_hp; // When full current_hp = stats[3,0]
    bool gender;//true=male//false=female
    string name;  //if null => name = species
    

    
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
    public Pokemon(int id, int level)
    {
        string[] pokemon_data = CSV_Read.ReadCSV("Pokemon", id).Split(',');
        //Debug.Log(pokemon_data);
        
        //initilize id
        id = System.Int32.Parse(pokemon_data[0]);

        //initilize next_evolution_lvl
        next_evolution_lvl = System.Int32.Parse(pokemon_data[1]);

        //initilize species name
        species = pokemon_data[2];

        //initilize type1_id and name
        type1_id = System.Int32.Parse(pokemon_data[3]);
        type1_name = pokemon_data[4];

        //initilize type2_id and name
        type2_id = System.Int32.Parse(pokemon_data[5]);
        type2_name = pokemon_data[6];

        //initilize Base Stats
        for (int i = 0; i < 6; i++)
            stats[0, i] = System.Int32.Parse(pokemon_data[i+7]);

        //initilize IV values
        for (int i = 0; i < 6; i++)
            stats[1, i] = Random.Range(0, 32);

        //initilize EV values
        for (int i = 0; i < 6; i++)
            stats[2, i] = 0;

        //initilize EV yields
        for (int i = 0; i < 6; i++)
            ev_yield[i] = System.Int32.Parse(pokemon_data[i + 13]);

        //initilize pokedex entry
        pokedex_entry = pokemon_data[19];

        //initilize calculate the total stats
        Calculate_Stats();
    }

    void Level_Up()
    {
        level++;
        Calculate_Stats();
    }

    
}

