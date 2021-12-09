using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CSV_Read : MonoBehaviour
{
    public static string  ReadCSV(string file, int row_id)
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Data/" + file + ".csv");
        bool endOfFile = false;
        int id = 1;

        while (!endOfFile)
        {
            string data_String = reader.ReadLine();

            if (data_String == null)
            {
                endOfFile = true;
                break;
            }

            if (id == row_id)
            {

                return data_String;
            }
            else
                id++;
        }

        return "not found";
        
    }
}
