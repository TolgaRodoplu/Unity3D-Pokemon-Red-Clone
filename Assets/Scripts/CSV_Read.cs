using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CSV_Read : MonoBehaviour
{
    public static string[]  ReadCSV(string file, int row_id, int mode)
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
            if (mode == 0)//for reading uniquely identified pokemon table
            {
                if (id == row_id)
                {
                    return data_String.Split(',');
                }
                else
                    id++;
            }
            if (mode == 1) //for reading from area spesific tables with spawn rates like "Route_1.csv"
            {
                string[] current_data = data_String.Split(',');
                if (row_id <= System.Int32.Parse(current_data[0]))
                {
                    return current_data;
                }
            }
        }

        string[] empty = {};
        return empty;
    }
}
