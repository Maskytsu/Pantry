using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] RectTransform _gridLayout;

    ListOfRecipies _listOfRecipies;
    TextMeshProUGUI[] _listOfTextMeshProUGUIs;
    TextMeshProUGUI[] _listOfTextMeshProUGUIsMenu;

    public void SpawnListOfRecipies()
    {
        //Usuwamy poprzedni¹ listê
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(Tags.RecipieTag);
        foreach (var item in gameObjects)
        {
            Destroy(item);
        }

        _listOfRecipies = GameObject.FindGameObjectWithTag(Tags.DataTag).GetComponent<ListOfRecipies>();

        _listOfRecipies.recipies.Sort();




        ///Sprawdzenie czy w liscie nie ma pustych nazw i usuwanie ich
        for (int j = 0; j < _listOfRecipies.recipies.Count; j++)
        {
            if (_listOfRecipies.recipies[j].title == "")
            {
                _listOfRecipies.recipies.
                    Remove(_listOfRecipies.recipies[j]);
                break;
            }
        }


        //Tworzymy listê i spawnujemy
        foreach (var item in _listOfRecipies.recipies)
        {

            GameObject newRecipie = Instantiate(_prefab);

            newRecipie.transform.SetParent(_gridLayout);

            _listOfTextMeshProUGUIs = newRecipie.GetComponentsInChildren<TextMeshProUGUI>();

            //Zamiana tekstu w buttonie
            for (int j = 0; j < _listOfTextMeshProUGUIs.Length; j++)
            {
                if (_listOfTextMeshProUGUIs[j].CompareTag(Tags.DataTitleTextTag))
                {
                    _listOfTextMeshProUGUIs[j].text = item.title;
                }
            }

            //Zamiana tekstu w menu
            List<GameObject> listOfChildren = new List<GameObject>();
            for (int i = 0; i < newRecipie.transform.childCount; i++)
            {
                    listOfChildren.Add(newRecipie.transform.GetChild(i).gameObject);
            }


            foreach (GameObject child in listOfChildren)
            {
                _listOfTextMeshProUGUIsMenu = child.GetComponentsInChildren<TextMeshProUGUI>();

                for (int j = 0; j < _listOfTextMeshProUGUIsMenu.Length; j++)
                {
                    if (_listOfTextMeshProUGUIsMenu[j].CompareTag(Tags.DataTitleTextTag))
                    {
                        _listOfTextMeshProUGUIsMenu[j].text = item.title;
                    }

                    if (_listOfTextMeshProUGUIsMenu[j].CompareTag(Tags.DataStepsTextTag))
                    {
                        _listOfTextMeshProUGUIsMenu[j].text = item.steps;
                    }

                    if (_listOfTextMeshProUGUIsMenu[j].CompareTag(Tags.DataIngridientsTextTag))
                    {
                        _listOfTextMeshProUGUIsMenu[j].text = item.ingridients;
                    }
                }
            }


            //Mo¿liwoœæ póŸniejszego odwo³ywania siê
            newRecipie.GetComponentInChildren<ObjectInListReference>().recipie = item;

        }
    }








}
