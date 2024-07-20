using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipie : ScriptableObject, IComparable<Recipie>
{
    public string title = "";
    public string steps = "";
    public string ingridients = "";


    public int CompareTo(Recipie comparePart)
    {
        if (comparePart == null)
            return 1;
        else
            return this.title.CompareTo(comparePart.title);
    }
}