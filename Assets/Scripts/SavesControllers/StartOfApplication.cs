using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfApplication : MonoBehaviour
{
    void Awake()
    {
        SavesController.LoadData();

        GameObject.FindGameObjectWithTag(Tags.SpawnerRecipiesTag).
        GetComponent<Spawner>().SpawnListOfRecipies();


    }
}
