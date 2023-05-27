using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector3 ToEulers;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float setTimer;
    [SerializeField]
    private float speed;
    private bool LerpLeft, LerpRight, LerpCenter;

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

        if (LerpLeft)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = setTimer;
                LerpLeft = false;
            }

            if (timer > 0f)
            {
               gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, -80f, Time.deltaTime * speed), 0f);
            }
        }

        if (LerpRight)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = setTimer;
                LerpRight = false;
            }

            if (timer > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 80f, Time.deltaTime * speed), 0f);
            }
        }

        if (LerpCenter)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = setTimer;
                LerpCenter = false;
            }

            if (timer > 0f)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(gameObject.transform.localEulerAngles.y, 0f, Time.deltaTime * speed), 0f);
            }
        }
    }
}
