using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintYellow : MonoBehaviour
{
    public static PaintYellow instance;
   
    #region boolPaint
    [HideInInspector]
    public bool isPaint = false;
    [HideInInspector]
    public bool isPaintYellow = false;
    [HideInInspector]
    public bool isPaintRed = false;
    [HideInInspector]
    public bool isPaintBlue = false;
    [HideInInspector]
    public bool isPaintGreen = false;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    // private float currentMoveSpeed;
    //private void Start()
    //{
    //    currentMoveSpeed = 2.5f;
    //}
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "PlayerSeek")
        {
            Debug.Log("Yellow");
            isPaint = true;
            isPaintYellow = true;
           // StartCoroutine(timePaint());
        }
        //else if (other.gameObject.tag == "PaintsRed")
        //{
        //    isPaint = true;
        //    isPaintRed = true;
        //    StartCoroutine(timePaint());
        //}
        //else if (other.gameObject.tag == "PaintsBlue")
        //{
        //    isPaint = true;
        //    isPaintBlue = true;
        //    StartCoroutine(timePaint());
        //}
        //else if (other.gameObject.tag == "PaintsGreen")
        //{
        //    isPaint = true;
        //    isPaintGreen = true;
        //    StartCoroutine(timePaint());
        //}
        //else
        //{
        //    isPaint = false;
        //    isPaintYellow = false;
        //    isPaintRed = false;
        //    isPaintBlue = false;
        //    isPaintGreen = false;
        //}

        //if (other.gameObject.tag == "PaintsGlue")
        //{

        //    StartCoroutine(changeMoveSpeedSlow());

        //}

        //if (other.gameObject.tag == "Speed")
        //{

        //    StartCoroutine(changeMoveSpeedFast());
        //    Destroy(other.gameObject);

        //}

    }
}
