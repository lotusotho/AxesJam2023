using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerBehaviour;

public class CutFood : MonoBehaviour
{
    PlayerBehaviour player;
    [SerializeField]
    private Transform TomateSpawner, PatataSpawner, CebollaSpawner;
    private void Start()
    {
        player = GameManager.Instance.PlayerBehaviour;
        TomateSpawner = GameObject.Find("TomateSpawnerCor").transform;
        PatataSpawner = GameObject.Find("PatataSpawnerCor").transform;
        CebollaSpawner = GameObject.Find("CebollaSpawnerCor").transform;
       }

    [SerializeField]
    private GameObject comida;
    private void OnCollisionEnter(Collision collision)
    {


        if (player.activeTool.Equals(ActiveTool.CUCHILLO) && collision.gameObject.tag.Equals("Player"))
        {

            if (comida.name == "RodajaTomate")
            {
                Instantiate(comida, TomateSpawner.transform);
                Debug.Log("Spawneo: " + comida.name);
                Destroy(gameObject);
            }

            if (comida.name == "PatatasFritas")
            {
                Instantiate(comida, PatataSpawner.transform);
                Debug.Log("Spawneo: " + comida.name);
                Destroy(gameObject);
            }

            if (comida.name == "RodajaCebolla")
            {
                Instantiate(comida, CebollaSpawner.transform);
                Debug.Log("Spawneo: " + comida.name);
                Destroy(gameObject);
            }
        }
    }
}
