using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string area = "Route_1";
    public List<Pokemon> team = new List<Pokemon>();

    private void Start()
    {
        string[] pokemon_data = CSV_Read.ReadCSV("Pokemon", 1, 0);
        team.Add(new Pokemon(pokemon_data, 5));
    }
}
