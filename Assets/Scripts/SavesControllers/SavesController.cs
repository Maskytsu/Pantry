using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavesController : MonoBehaviour
{

    public static void SaveData()
    {
        GameObject _object = GameObject.FindGameObjectWithTag(Tags.DataTag);

        string path = (Application.platform == RuntimePlatform.Android ||
        Application.platform == RuntimePlatform.IPhonePlayer ?
        Application.persistentDataPath : Application.dataPath) + "/PantrySave.json";

        string json;

        File.WriteAllText(path, "start\n");

        foreach (var item in _object.GetComponent<ListOfRecipies>().recipies)
        { 
                json = JsonUtility.ToJson(item);
                File.AppendAllText(path, json + "\n");
        }
        File.AppendAllText(path, "end\n");
    }




    public static void LoadData()
    {

        GameObject _object = GameObject.FindGameObjectWithTag(Tags.DataTag);

        string path = (Application.platform == RuntimePlatform.Android ||
        Application.platform == RuntimePlatform.IPhonePlayer ?
        Application.persistentDataPath : Application.dataPath) + "/PantrySave.json";

        if(File.Exists(path))
        {
            string json;
            int i = 1;

            json = File.ReadAllLines(path)[i];
            while (json != "end")
            {
                Recipie item = ScriptableObject.CreateInstance("Recipie") as Recipie;
                JsonUtility.FromJsonOverwrite(json, item);
                _object.GetComponent<ListOfRecipies>().recipies.Add(item);
                i++;
                json = File.ReadAllLines(path)[i];
            }
        }
    }
}