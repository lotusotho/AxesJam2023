using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _timerCameraChanger, _timerToolChanger, _barTimer;
    [SerializeField]
    private float _setTimer, _setToolChanger;
    [SerializeField]
    [Range(0f, 2f)]
    private float _speed;
    private bool _lerpLeft, _lerpRight, _lerpCenter;
    [SerializeField]
    private GameObject[] _tools;
    [SerializeField]
    private int _toolsChanger;
    //UI
    [SerializeField]
    private Image _selector;
    [SerializeField]
    private RectTransform[] _UIPositions;
    [SerializeField]
    private Transform _changingBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        //Inputs para lerping
        if (Input.GetKeyDown(KeyCode.A))
        {
            LerpToLeft();
            Debug.Log("Lerping");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LerpToRight();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            LerpToCenter();
        }

        //Funciones de lerping
        void LerpToLeft()
        {
            _lerpLeft = true;
        }

        void LerpToRight()
        {
            _lerpRight = true;
        }

        void LerpToCenter()
        {
            _lerpCenter = true;
        }

        //Cambiar de herramienta
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selector.rectTransform.position = _UIPositions[0].transform.position;
            _toolsChanger = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _selector.rectTransform.position = _UIPositions[1].transform.position;
            _toolsChanger = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _selector.rectTransform.position = _UIPositions[2].transform.position;
            _toolsChanger = 3;
        }

        //Sacar nueva herramienta
        if (_timerToolChanger > 0f && Input.GetButtonUp("Fire2"))
        {
            _timerToolChanger = _setToolChanger;
        }

        if (_timerToolChanger > 0f && Input.GetButton("Fire2"))
        {
            _timerToolChanger -= Time.deltaTime;
        }

        if (_timerToolChanger <= 0f && _toolsChanger == 1 && Input.GetButton("Fire2"))
        {
            for(int i = 0; i < _tools.Length; i++)
            {
                _tools[i].SetActive(false);
            }
            _tools[0].SetActive(true);
            _timerToolChanger = _setToolChanger;
        }

        if (_timerToolChanger <= 0f && _toolsChanger == 2 && Input.GetButton("Fire2"))
        {
            for (int i = 0; i < _tools.Length; i++)
            {
                _tools[i].SetActive(false);
            }
            _tools[1].SetActive(true);
            _timerToolChanger = _setToolChanger;
        }

        //Barra de cambiar de herramientas Update

        if (Input.GetButton("Fire2"))
        {
            _barTimer += Time.deltaTime;
        }
        else if (_barTimer != 0f)
        {
            _barTimer -= Time.deltaTime * 2;
            _timerToolChanger = _setToolChanger;
        }

        if (_barTimer >= .8f)
        {
            _changingBar.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 5f));
        }
        else _changingBar.transform.eulerAngles = Vector3.zero;

        _changingBar.transform.localScale = new Vector3(_barTimer, 1f, 1f);
        _barTimer = Mathf.Clamp(_barTimer, 0f, 1f);
        print(_barTimer);

        //Timers
        if (_lerpLeft)
        {
            _timerCameraChanger -= Time.deltaTime;
            if (_timerCameraChanger <= 0f)
            {
                _timerCameraChanger = _setTimer;
                _lerpLeft = false;
            }

            if (_timerCameraChanger > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, -80f, Time.deltaTime * _speed), 0f);
            }
        }

        if (_lerpRight)
        {
            _timerCameraChanger -= Time.deltaTime;
            if (_timerCameraChanger <= 0f)
            {
                _timerCameraChanger = _setTimer;
                _lerpRight = false;
            }

            if (_timerCameraChanger > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 80f, Time.deltaTime * _speed), 0f);
            }
        }

        if (_lerpCenter)
        {
            _timerCameraChanger -= Time.deltaTime;
            if (_timerCameraChanger <= 0f)
            {
                _timerCameraChanger = _setTimer;
                _lerpCenter = false;
            }

            if (_timerCameraChanger > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 0f, Time.deltaTime * _speed), 0f);
            }
        }
    }
}
