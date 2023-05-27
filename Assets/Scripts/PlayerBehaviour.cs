using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector3 ToEulers;
    [SerializeField]
    private float timerCameraChanger, timerToolChanger, barTimer;
    [SerializeField]
    private float setTimer, setToolChanger;
    [SerializeField]
    [Range(0f, 2f)]
    private float speed;
    private bool LerpLeft, LerpRight, LerpCenter;
    [SerializeField]
    private GameObject[] Tools;
    [SerializeField]
    private int toolsChanger;
    //UI
    [SerializeField]
    private Image Selector;
    [SerializeField]
    private RectTransform[] UIPositions;
    [SerializeField]
    private Transform ChangingBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        //Inputs para lerping
        ToEulers = gameObject.transform.rotation.eulerAngles;
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
            LerpLeft = true;
        }

        void LerpToRight()
        {
            LerpRight = true;
        }

        void LerpToCenter()
        {
            LerpCenter = true;
        }

        //Cambiar de herramienta
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Selector.rectTransform.position = UIPositions[0].transform.position;
            toolsChanger = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Selector.rectTransform.position = UIPositions[1].transform.position;
            toolsChanger = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Selector.rectTransform.position = UIPositions[2].transform.position;
            toolsChanger = 3;
        }

        //Sacar nueva herramienta
        if (timerToolChanger > 0f && Input.GetButtonUp("Fire2"))
        {
            timerToolChanger = setToolChanger;
        }

        if (timerToolChanger > 0f && Input.GetButton("Fire2"))
        {
            timerToolChanger -= Time.deltaTime;
        }

        if (timerToolChanger <= 0f && toolsChanger == 1 && Input.GetButton("Fire2"))
        {
            for(int i = 0; i < Tools.Length; i++)
            {
                Tools[i].SetActive(false);
            }
            Tools[0].SetActive(true);
            timerToolChanger = setToolChanger;
        }

        if (timerToolChanger <= 0f && toolsChanger == 2 && Input.GetButton("Fire2"))
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                Tools[i].SetActive(false);
            }
            Tools[1].SetActive(true);
            timerToolChanger = setToolChanger;
        }

        //Barra de cambiar de herramientas Update

        if (Input.GetButton("Fire2"))
        {
            barTimer += Time.deltaTime;
        }
        else if (barTimer != 0f)
        {
            barTimer -= Time.deltaTime * 2;
            timerToolChanger = setToolChanger;
        }

        if (barTimer >= .8f)
        {
            ChangingBar.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 5f));
        }
        else ChangingBar.transform.eulerAngles = Vector3.zero;

        ChangingBar.transform.localScale = new Vector3(barTimer, 1f, 1f);
        barTimer = Mathf.Clamp(barTimer, 0f, 1f);
        print(barTimer);

        //Timers
        if (LerpLeft)
        {
            timerCameraChanger -= Time.deltaTime;
            if (timerCameraChanger <= 0f)
            {
                timerCameraChanger = setTimer;
                LerpLeft = false;
            }

            if (timerCameraChanger > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, -80f, Time.deltaTime * speed), 0f);
            }
        }

        if (LerpRight)
        {
            timerCameraChanger -= Time.deltaTime;
            if (timerCameraChanger <= 0f)
            {
                timerCameraChanger = setTimer;
                LerpRight = false;
            }

            if (timerCameraChanger > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 80f, Time.deltaTime * speed), 0f);
            }
        }

        if (LerpCenter)
        {
            timerCameraChanger -= Time.deltaTime;
            if (timerCameraChanger <= 0f)
            {
                timerCameraChanger = setTimer;
                LerpCenter = false;
            }

            if (timerCameraChanger > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 0f, Time.deltaTime * speed), 0f);
            }
        }
    }
}
