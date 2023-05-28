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

    private GameObject finishedRecipe;

    public FinishedPlate finishedPlate;

    public Transform finishedSpawnLocation;

    private void Awake()
    {
        currentIngredients = new List<string>();
        requiredIngredients = new List<string>();
    }

    private void Start()
    {
        currentIngredientsObj = new List<GameObject>();
    }

    private void Update()
    {
        CheckIfRecipeIsComplete();
        
    }

    public void SetRequiredIngredients(List<String> required)
    {
        if (required != null)
        {
            foreach (string food in required)
            {
                requiredIngredients.Add(food);
            }
        }
       
    }

    
    public void SetFinishedRecipe(GameObject finished)
    {
        finishedRecipe = finished;
        finishedPlate.SetRequiredRecipe(finished);
        
    }

    private void CheckIfRecipeIsComplete()
    {
        if (requiredIngredients != null && currentIngredients != null && requiredIngredients.Count > 0)
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
                
                if (GameManager.Instance.PlayerBehaviour.itemOnHand)
                {
                    GameManager.Instance.PlayerBehaviour.itemOnHand = false;
                }
                
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
