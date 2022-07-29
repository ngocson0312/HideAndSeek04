using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPaint : MonoBehaviour
{
    #region --- helpers --
    public enum enumFoot
    {
        Left,
        Right,
    }
    #endregion

    public GameObject LeftPrefab;
    public GameObject RightPrefab;
    public float FootprintSpacer = 1.0f;
    private Vector3 LastFootprint;
    private enumFoot WhichFoot;
    public GameObject[] intdexPos;

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
    private void Start()
    {
        Color color = Color.clear;
        LastFootprint = this.transform.position;
        LeftPrefab.GetComponent<SpriteRenderer>().color = color;
        RightPrefab.GetComponent<SpriteRenderer>().color = color;
    }

    private void Update()
    {

        FootPaints();
        CheckPaint();

    }

    public void FootPaints()
    {
        if (GetComponent<CheckPaintItem>().isPaint ==true)
        {
            float DistanceSinceLastFootprint = Vector3.Distance(transform.position, LastFootprint);
            if (DistanceSinceLastFootprint >= FootprintSpacer)
            {
                LastFootprint = this.transform.position;
                if (WhichFoot == enumFoot.Left)
                {
                    SpawnFootDecal(LeftPrefab);
                    WhichFoot = enumFoot.Right;
                }
                else if (WhichFoot == enumFoot.Right)
                {
                    SpawnFootDecal(RightPrefab);
                    WhichFoot = enumFoot.Left;
                }
                LastFootprint = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            }
        }

    }

    public void CheckPaint()
    {
        if(GetComponent<CheckPaintItem>().isPaintYellow == true && GetComponent<CheckPaintItem>().isPaint == true)
        {
            LeftPrefab.GetComponent<SpriteRenderer>().color = Color.yellow;
            RightPrefab.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (GetComponent<CheckPaintItem>().isPaintRed == true && GetComponent<CheckPaintItem>().isPaint == true)
        {
            LeftPrefab.GetComponent<SpriteRenderer>().color = Color.red;
            RightPrefab.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (GetComponent<CheckPaintItem>().isPaintBlue == true && GetComponent<CheckPaintItem>().isPaint == true)
        {
            LeftPrefab.GetComponent<SpriteRenderer>().color = Color.blue;
            RightPrefab.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (GetComponent<CheckPaintItem>().isPaintGreen == true && GetComponent<CheckPaintItem>().isPaint == true)
        {
            LeftPrefab.GetComponent<SpriteRenderer>().color = Color.green;
            RightPrefab.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Color color = Color.clear;
        LeftPrefab.GetComponent<SpriteRenderer>().color = color;
        RightPrefab.GetComponent<SpriteRenderer>().color = color;
    }


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "PaintsYellow")
        {
            Debug.Log("Yellow");
            isPaint = true;
            isPaintYellow = true;
            StartCoroutine(timePaint());
        }
        else if (other.gameObject.tag == "PaintsRed")
        {
            isPaint = true;
            isPaintRed = true;
            StartCoroutine(timePaint());
        }
        else if (other.gameObject.tag == "PaintsBlue")
        {
            isPaint = true;
            isPaintBlue = true;
            StartCoroutine(timePaint());
        }
        else if (other.gameObject.tag == "PaintsGreen")
        {
            isPaint = true;
            isPaintGreen = true;
            StartCoroutine(timePaint());
        }
        else
        {
            isPaint = false;
            isPaintYellow = false;
            isPaintRed = false;
            isPaintBlue = false;
            isPaintGreen = false;
        }

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



    IEnumerator timePaint()
    {
        yield return new WaitForSeconds(10f);
        isPaint = false;

    }

    public void SpawnFootDecal(GameObject prefab)
    {

        int index = Random.Range(0, intdexPos.Length);
        //where the ray hits the ground we will place a footprint

        GameObject decal = Instantiate(prefab);

        decal.transform.position = intdexPos[index].transform.position;
        
        decal.transform.Rotate(Vector3.forward, intdexPos[index].transform.eulerAngles.y);
        //turn the footprint to match the direction the player is facing


    }
}
