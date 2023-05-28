using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneValues : MonoBehaviour
{
    public bool Cocinado = false;
    public bool Quemado = false;
    public bool NewCarne = true;
    public bool StartTimer = false;
    private float _speed = 3f;
    public float FoodTimer = 100f;

    public void CocinarCarne()
    {
        if (StartTimer)
        {
            FoodTimer -= Time.deltaTime * _speed;
            if (FoodTimer < 30f)
            {
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(173 / 255f, 173 / 255f, 173 / 255f, 1f));
                Cocinado = true;
                gameObject.tag = "Carne";
            }

            if (FoodTimer < 10f)
            {
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(49 / 255f, 49 / 255f, 49 / 255f, 1f));
                Cocinado = false;
                Quemado = true;
                gameObject.tag = "Carnequemada";
            }
        }
    }

    public void RetirarCarne()
    {
        StartTimer = false;
        if (gameObject.tag == "Carnequemada")
        {
            Destroy(gameObject);
        }
    }
}
