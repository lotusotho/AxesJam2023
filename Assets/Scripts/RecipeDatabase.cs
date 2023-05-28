using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase
{
    public Dictionary<int, List<string>> recipes = new Dictionary<int, List<string>>
    {
        //Menu 1
        { 1, new List<string>() {  "PanBajo", "Patatasfritas" }},
        //Menu 2
        { 2, new List<string>() {  "PanBajo", "Carne", "Lechuga", "Queso", "Queso", "Queso", "Queso", "Patatasfritas", "Patatasfritas", "PanAlto" }},
        //Menu 3
        { 3, new List<string>() {  "PanBajo", "PanAlto", "Carne", "Carne", "Tomate", "Tomate", "Lechuga", "Patatasfritas"}},
        //Menu 4
        { 4, new List<string>() {  "PanAlto", "PanBajo", "Carne", "Carne", "Lechuga", "Lechuga", "Queso", "Queso", "Tomate", "Tomate", "Cebolla", "Patatasfritas"}},
        //Menu 5
        { 5, new List<string>() {  "PanAlto", "PanBajo", "Carne", "Queso"}},
        //Menu 6
        { 6, new List<string>() {  "Tomate", "Tomate", "Lechuga", "Lechuga", "Lechuga", "Lechuga", "Cebolla", "Cebolla"} },
       
    };
}
