using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddRecipie : MonoBehaviour
{
    [SerializeField] TMP_InputField _titleInputFiled;
    [SerializeField] TMP_InputField _stepsInputFiled;
    [SerializeField] TMP_InputField _ingridientsInputFiled;
    ListOfRecipies _data;
    private void Start()
    {
        _data = GameObject.FindGameObjectWithTag(Tags.DataTag).GetComponent<ListOfRecipies>();
    }
    public void AddRecipieFun()
    {
        Recipie recipie = ScriptableObject.CreateInstance("Recipie")
            as Recipie;

        recipie.title = _titleInputFiled.text;
        recipie.steps = _stepsInputFiled.text;
        recipie.ingridients = _ingridientsInputFiled.text;

        _data.recipies.Add(recipie);
    }
}
