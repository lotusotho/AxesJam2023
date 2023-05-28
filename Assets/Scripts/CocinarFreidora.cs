using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CocinarFreidora : MonoBehaviour
{
    private float _foodtimer;
    private bool _starttimer;
    private GameObject _patataparrilla;

    [SerializeField]
    private float _setTimer;

    [SerializeField]
    private float _speed;

    private bool _cocinado, _quemado, _newpatata;

    public List<PatataValues> patatas;

    // Start is called before the first frame update
    void Start()
    {
        _starttimer = false;
        patatas = new List<PatataValues>();
    }

    // Update is called once per frame
    void Update()
    {

        if(patatas.Count > 0)
        {
            foreach(PatataValues patata in patatas)
            {
                patata.CocinarPatata();
            }
        }


        if (_starttimer)
        {
            _foodtimer -= Time.deltaTime * _speed;
            if (_foodtimer < 30f)
            {
                _patataparrilla.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(215 / 255f, 194 / 255f, 37 / 255f, 1f));
                _cocinado = true;
            }

            if (_foodtimer < 10f)
            {
                _patataparrilla.GetComponent<MeshRenderer>().material.SetColor("_Litcolor", new Color(97 / 255f, 88 / 255f, 17 / 255f, 1f));
                _cocinado = false;
                _quemado = true;
                _patataparrilla.tag = "Patatasquemadas";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PatataValues>() != null)
        {

            patatas.Add(other.gameObject.GetComponent<PatataValues>());
            other.gameObject.GetComponent<PatataValues>().StartTimer = true;
        }
        
        if (other.gameObject.GetComponent<PatataValues>() == null && other.gameObject.layer == LayerMask.NameToLayer("Grabbable") || other.gameObject.GetComponent<PatataValues>() == null && other.gameObject.layer == LayerMask.NameToLayer("GrabbableFinished"))
        {
            Destroy(other.gameObject);
        }

        /*
        if (other.gameObject.tag == "patata")
        {
            _patataparrilla = other.gameObject;
            _starttimer = true;
            _newpatata = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PatataValues>() != null)
        {

            patatas.Remove(other.gameObject.GetComponent<PatataValues>());

            /*
            _starttimer = false;
            _patataparrilla.GetComponent<patataValues>().FoodTimer = _foodtimer;

            if (other.gameObject.tag == "patataquemada")
            {
                Destroy(other.gameObject);
            }*/
        }
    }
}
