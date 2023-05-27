using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorColliders : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Alimentos;

    [SerializeField]
    private int _alimentoIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Alimentos[_alimentoIndex], gameObject.transform);
        }
    }
}
