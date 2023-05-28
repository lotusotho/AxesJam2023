using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorColliders : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Alimentos;

    private Transform _dispensadorSpawner;

    [SerializeField]
    private int _alimentoIndex;

    private void Start()
    {
        _dispensadorSpawner = GameObject.Find("DispensadorSpawner").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Alimentos[_alimentoIndex], new Vector3(_dispensadorSpawner.transform.position.x + _alimentoIndex / 2.5f, _dispensadorSpawner.transform.position.y, _dispensadorSpawner.transform.position.z), _dispensadorSpawner.transform.localRotation);
        }
    }
}
