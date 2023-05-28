using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedPlate : MonoBehaviour
{
    private GameObject requiredRecipe;

    //Cuando se coloque un plato finalizado en el OnTriggerEnter...
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("GrababbleFinished"))
        {
            if (requiredRecipe.tag.Equals(other.tag))
            {
                //El objeto que hay en el plato verde coincide con lo que se necesita, en Game Manager hacemos ajustes para parar temporizador, cambiar cliente, etc.
                GameManager.Instance.currentClient.PedidoHecho();
                GameManager.Instance.AddPoints();
                Destroy(other.gameObject);
            }
        }
    }

    public void SetRequiredRecipe(GameObject recipe)
    {
        requiredRecipe = recipe;
    }
    
    
}
