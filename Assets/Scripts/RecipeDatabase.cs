using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase
{
    public Dictionary<int, List<string>> recipes = new Dictionary<int, List<string>>
    {
        { 1, new List<string>() { "PanBajo", "PanAlto", "Carne" } },
        { 2, new List<string>() {  "PanBajo", "PanAlto", "Carne", "Tomate" }}
    };
}
