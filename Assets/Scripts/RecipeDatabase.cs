using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase
{
    public Dictionary<string, List<string>> recipes = new Dictionary<string, List<string>>
    {
        { "Hamburguesa", new List<string>() { "PanBajo", "PanAlto", "Carne" } },
        { "Hamburguesa con tomate", new List<string>() {  "PanBajo", "PanAlto", "Carne", "Tomate" }}
    };
}
