using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CocinarParrilla : MonoBehaviour
{
    private float _foodtimer;
    private bool _starttimer;
    private GameObject _carneparrilla;

    [SerializeField]
    private float _setTimer;

    [SerializeField]
    private float _speed;

    private bool _cocinado, _quemado, _newcarne;

    public List<CarneValues> carnes;

    // Start is called before the first frame update
    void Start()
    {
        _starttimer = false;
        carnes = new List<CarneValues>();
    }

    // Update is called once per frame
    void Update()
    {

        if(carnes.Count > 0)
        {
            foreach(CarneValues carne in carnes)
            {
                carne.CocinarCarne();
            }
        }


        if (_starttimer)
        {
            _foodtimer -= Time.deltaTime * _speed;
            if (_foodtimer < 30f)
            {
                _carneparrilla.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(173 / 255f, 173 / 255f, 173 / 255f, 1f));
                _cocinado = true;
            }

            if (_foodtimer < 10f)
            {
                _carneparrilla.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(49 / 255f, 49 / 255f, 49 / 255f, 1f));
                _cocinado = false;
                _quemado = true;
                _carneparrilla.tag = "Carnequemada";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarneValues>() != null)
        {

            carnes.Add(other.gameObject.GetComponent<CarneValues>());
            other.gameObject.GetComponent<CarneValues>().StartTimer = true;
        }
        
        /*
        if (other.gameObject.tag == "Carne")
        {
            _carneparrilla = other.gameObject;
            _starttimer = true;
            _newcarne = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CarneValues>() != null)
        {

            carnes.Remove(other.gameObject.GetComponent<CarneValues>());

            /*
            _starttimer = false;
            _carneparrilla.GetComponent<CarneValues>().FoodTimer = _foodtimer;

            if (other.gameObject.tag == "Carnequemada")
            {
                Destroy(other.gameObject);
            }*/
        }
    }
}
