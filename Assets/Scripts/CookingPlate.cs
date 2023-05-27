using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CookingPlate : MonoBehaviour
{
    private List<string> requiredIngredients;
    private List<string> currentIngredients;
    private List<GameObject> currentIngredientsObj;

    public GameObject finishedRecipe;

    public Transform finishedSpawnLocation;

    private RecipeDatabase database;

    public BoxCollider triggerIngredients;
    

    private void Start()
    {
        database = new RecipeDatabase();
        currentIngredients = new List<string>();
        requiredIngredients = new List<string>();
        currentIngredientsObj = new List<GameObject>();
        requiredIngredients = database.recipes["Hamburguesa"];
    }

    private void Update()
    {
        CheckIfRecipeIsComplete();
        
    }

    private void CheckIfRecipeIsComplete()
    {
        if (requiredIngredients != null && currentIngredients != null)
        {
            bool sameValues = requiredIngredients.OrderBy(x => x).SequenceEqual(currentIngredients.OrderBy(x => x));

            //Ingredientes listos, montamos la receta
            if (sameValues)
            {
                foreach (GameObject food in currentIngredientsObj)
                {
                    Destroy(food);
                   
                }
                
                GameObject finishedFood = Instantiate(finishedRecipe);
                finishedFood.transform.position = finishedSpawnLocation.position;
                currentIngredients.Clear();
                
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grabbable"))
        {
            currentIngredients.Add(other.gameObject.tag);
            currentIngredientsObj.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grabbable"))
        {
            currentIngredients.Remove(other.gameObject.tag);
            currentIngredientsObj.Remove(other.gameObject);
        }
    }

    
}
