using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    public List<string> requiredIngredients;

    public int points;

    public ClientBehaviour currentClient;

    public CookingPlate cookingPlate;

    public RecipeDatabase RecipeDatabase;

    public List<GameObject> completeRecipes;
    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        RecipeDatabase database = new RecipeDatabase();
        
        requiredIngredients = database.recipes[currentClient.NumeroPedido+1];
        
        Debug.Log(requiredIngredients.Count);
        
        Debug.Log("Asignando " + currentClient.NumeroPedido);
        
       cookingPlate.SetRequiredIngredients(requiredIngredients);
       cookingPlate.SetFinishedRecipe(completeRecipes[currentClient.NumeroPedido+1]);
        
    }
    
    
}
