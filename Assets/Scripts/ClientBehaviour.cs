using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClientBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _dialogueTXT;

    private TMP_Text _temporizadorTXT;

    public int NumeroPedido;

    private int MinimumRange = 1;
    private int MaximumRange = 5;

    [SerializeField]
    private float _timer;

    [SerializeField]
    private int _maxTimerRandomizer;

    [SerializeField]
    private int _minTimerRandomizer;

    [SerializeField]
    private bool _doRandomize;

    private string _minutes;

    private string _seconds;

    private int _pedidoCase;

    // Start is called before the first frame update
    private void Start()
    {
        NumeroPedido = Random.Range(MinimumRange, MaximumRange);
        _dialogueTXT.text = "Quiero un número <b>" + NumeroPedido + "</b>, por favor";
        _temporizadorTXT = GameObject.FindGameObjectWithTag("temporizador").GetComponent<TMP_Text>();

        if (_doRandomize)
        {
            Random.Range(_minTimerRandomizer, _maxTimerRandomizer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Temporizador
        _minutes = Mathf.Floor(_timer / 60).ToString("00");
        _seconds = (_timer % 60).ToString("00");

        _temporizadorTXT.text = string.Format("{0}:{1}", _minutes, _seconds);

        _timer -= Time.deltaTime;


        //if (_doRandomize && _timer == 150f)
        //{
        //    Random.Range(_minTimerRandomizer / 2.5f, _maxTimerRandomizer / 2.5f);
        //}
    }

    public void PedidoHecho()
    {
        _pedidoCase = Random.Range(1, 2);
        switch (_pedidoCase)
        {
            case 1:
                _temporizadorTXT.text = "¡Muchas gracias!";
            break;
            case 2:
                _temporizadorTXT.text = "¡Wow, gracias!";
                break;
        }
        GameManager.Instance.points++;
        Destroy(gameObject, 2f);
    }
}
