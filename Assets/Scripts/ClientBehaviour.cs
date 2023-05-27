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

    [Range(1, 2)]
    private int MaximumRange;

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

    public GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        NumeroPedido = Random.Range(1, MaximumRange);
        _dialogueTXT.text = "Quiero un n�mero <b>" + NumeroPedido + "</b>, por favor";
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
}
