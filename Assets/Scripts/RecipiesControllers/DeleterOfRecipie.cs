using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterOfRecipie : MonoBehaviour
{
    [SerializeField] ObjectInListReference _objectInListReference;

    public void DeleteRecipie()
    {
        _objectInListReference.recipie.title = "";

        GameObject.FindGameObjectWithTag(Tags.SpawnerRecipiesTag).
            GetComponent<Spawner>().SpawnListOfRecipies();
    }
}