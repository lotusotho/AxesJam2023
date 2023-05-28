using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatataValues : MonoBehaviour
{
    public bool Cocinado = false;
    public bool Quemado = false;
    public bool NewPatata = true;
    public bool StartTimer = false;
    private float _speed = 4f;
    public float FoodTimer = 100f;

    public void CocinarPatata()
    {
        if (StartTimer)
        {
            FoodTimer -= Time.deltaTime * _speed;
            if (FoodTimer < 30f)
            {
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(239 / 255f, 215 / 255f, 40 / 255f, 1f));
                Cocinado = true;
                gameObject.tag = "Patatasfritas";
            }

            if (FoodTimer < 10f)
            {
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(130 / 255f, 117 / 255f, 21 / 255f, 1f));
                Cocinado = false;
                Quemado = true;
                gameObject.tag = "Patatasquemadas";
            }
        }
    }

    public void RetirarPatata()
    {
        StartTimer = false;
        if (gameObject.tag == "Patatasquemadas")
        {
            Destroy(gameObject);
        }
    }
}
