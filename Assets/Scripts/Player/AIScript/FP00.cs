using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP00 : MonoBehaviour
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


    private void Start()
    {
        LastFootprint = transform.position;
    }

    private void Update()
    {
        FootPaints();

    }
    public void FootPaints()
    {
        if (AI00.instance.isPaint == true)
        {
            float DistanceSinceLastFootprint = Vector3.Distance(transform.position, LastFootprint);
            if (DistanceSinceLastFootprint >= FootprintSpacer)
            {
                LastFootprint = transform.position;
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
