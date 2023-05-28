using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public enum ActiveTool
    {
        MANO, ESPATULA, CUCHILLO
    }
    
    [SerializeField]
    private float _timerCameraChanger, _timerToolChanger, _barTimer;
    
    [SerializeField]
    private float _setTimer, _setToolChanger;

    [SerializeField] private float timerChangeTool, requiredChangeToolTime;
    
    [SerializeField]
    [Range(0f, 2f)]
    private float _speed;
    private bool _lerpLeft, _lerpRight, _lerpCenter;
    
    [SerializeField]
    private GameObject[] _tools;

    private int indexCurrentTool = 0;

    private bool isChanging = false, canChange = true;
    
    [SerializeField]
    private int _toolsChanger;
    //UI
    [SerializeField]
    private Image _selector;
    [SerializeField]
    private RectTransform[] _UIPositions;
    [SerializeField]
    private Transform _changingBar;

    public ActiveTool activeTool;

    public Image fillImage;

    private bool isFilling = false;
    private float currentFillAmount = 0f;
    private float targetFillAmount = 1f;

    public float fillSpeed = 2f;

    public bool itemOnHand = false;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _tools.Length; i++)
        {
            _tools[i].SetActive(false);
        }
        _tools[0].SetActive(true);
        ChangeActiveTool();
        _timerToolChanger = _setToolChanger;
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

        CheckChangeTool();
        
       
        /*
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

        if (_timerToolChanger <= 0f && _toolsChanger == 3 && Input.GetButton("Fire2"))
        {
            for (int i = 0; i < _tools.Length; i++)
            {
                _tools[i].SetActive(false);
            }
            _tools[2].SetActive(true);
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
*/
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
                gameObject.transform.localEulerAngles = new Vector3(17.069f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, -80f, Time.deltaTime * _speed), 0f);
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
                gameObject.transform.localEulerAngles = new Vector3(17.069f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 80f, Time.deltaTime * _speed), 0f);
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
                gameObject.transform.localEulerAngles = new Vector3(17.069f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 0f, Time.deltaTime * _speed), 0f);
            }
        }
    }

    private void CheckChangeTool()
    {

        if (Input.GetButton("Fire2") && canChange && !itemOnHand)
        {
            isChanging = true;
            isFilling = true;
            fillImage.gameObject.SetActive(true);

        }
        else
        {
            isChanging = false;
            isFilling = false;
            currentFillAmount = 0f;
            fillImage.fillAmount = 0f;
            fillImage.gameObject.SetActive(false);
            timerChangeTool = 0f;
        }

        if (Input.GetButtonUp("Fire2") && !canChange)
        {
            canChange = true;
        }

        if (isChanging)
        {
            timerChangeTool += Time.deltaTime;

            if (isFilling)
            {
                currentFillAmount += Time.deltaTime * fillSpeed;
                currentFillAmount = Mathf.Clamp01(currentFillAmount);
                fillImage.fillAmount = currentFillAmount;

                if (currentFillAmount >= targetFillAmount)
                {
                    isFilling = false;
                }
            }
          
            
            if (timerChangeTool >= requiredChangeToolTime)
            {

                timerChangeTool = 0f;
                
                _tools[indexCurrentTool].SetActive(false);

                if (indexCurrentTool + 1 >= _tools.Length)
                {
                    indexCurrentTool = 0;
                }
                else
                {
                    indexCurrentTool++;
                }
                
                _tools[indexCurrentTool].SetActive(true);
                ChangeActiveTool();

                canChange = false;
                isChanging = false;

            }
        }

        if (isFilling)
        {
            
        }
    }

    private void ChangeActiveTool()
    {
        switch (indexCurrentTool)
        {
            case 0:
                activeTool = ActiveTool.MANO;
                break;
            case 1:
                activeTool = ActiveTool.ESPATULA;
                break;
            case 2:
                activeTool = ActiveTool.CUCHILLO;
                break;
        }
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
}
