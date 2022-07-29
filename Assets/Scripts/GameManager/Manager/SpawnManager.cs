using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    //[SerializeField] string SpawnPointMapTag = "SpawnPointMap";
    //[SerializeField] List<GameObject> PrefabMap;

    [SerializeField] string SpawnPointAITag = "SpawnPointAI";
    [SerializeField] List<GameObject> PrefabsAI;

    [SerializeField] string SpawnPointPlayerTag ="SpawnPointPlayer";
    [SerializeField] GameObject PrefabPlayer;

    [SerializeField] string SpawnPointPaintsTag ="SpawnPointPaint";
    [SerializeField] List<GameObject> PrefabsPaints;

    [SerializeField] string SpawnPointSpeedTag ="SpawnPointSpeed";
    [SerializeField] List<GameObject> PrefabSpeed;

    [SerializeField] string SpawnPointClockTag ="SpawnPointClock";
    [SerializeField] List<GameObject> PrefabsClock;

    [SerializeField] bool alwaySpawn = true;

  

    private void Awake()
    {
        instance = this;
        //SpawnMap();
    }
    private void Start()
    {
        SpawnPlayerCenter();
        SpawnAIAround();
        SpawnPaints();
        SpawnClock();
        SpawnSpeed();
        
      //  StartCoroutine(timeScale());
    }

    //public void SpawnMap()
    //{
    //    GameObject[] MapPoint = GameObject.FindGameObjectsWithTag(SpawnPointMapTag);

    //    foreach (GameObject item in MapPoint)
    //    {
    //        if (alwaySpawn)
    //        {
    //            int 
    //            GameObject pts = Instantiate(PrefabMap[GameManager.instance.level], transform);
    //            pts.transform.position = item.transform.position;
    //            pts.transform.rotation = item.transform.rotation;
    //        }
    //    }
    //}


    public void SpawnPlayerCenter()
    {
        GameObject PlayerPoint = GameObject.FindGameObjectWithTag(SpawnPointPlayerTag);

        GameObject Player = Instantiate(PrefabPlayer);
        Player.transform.position = PlayerPoint.transform.position;
    }

    public void SpawnClock()
    {
        GameObject[] ClockPoint = GameObject.FindGameObjectsWithTag(SpawnPointClockTag);

        foreach (GameObject item in ClockPoint)
        {
            int random = Random.Range(0, PrefabsClock.Count);
            if (alwaySpawn)
            {
                GameObject pts = Instantiate(PrefabsClock[random],transform);
                pts.transform.position = item.transform.position;
                pts.transform.rotation = item.transform.rotation;
            }
            else
            {
                int spawnOrNot = Random.Range(0, 2);
                if (spawnOrNot == 0)
                {
                    GameObject ptss = Instantiate(PrefabsClock[random]);
                    ptss.transform.position = item.transform.position;
                }
            }
        }
    }


    public void SpawnSpeed()
    {
        GameObject[] SpeedPoint = GameObject.FindGameObjectsWithTag(SpawnPointSpeedTag);

        foreach (GameObject item in SpeedPoint)
        {
            int random = Random.Range(0, PrefabSpeed.Count);
            if (alwaySpawn)
            {
                GameObject pts = Instantiate(PrefabSpeed[random]);
                pts.transform.position = item.transform.position;
                pts.transform.rotation = item.transform.rotation;
            }
            else
            {
                int spawnOrNot = Random.Range(0, 2);
                if (spawnOrNot == 0)
                {
                    GameObject ptss = Instantiate(PrefabSpeed[random]);
                    ptss.transform.position = item.transform.position;
                }
            }
        }
    }




    public void SpawnAIAround()
    {
        GameObject[] AIPoint = GameObject.FindGameObjectsWithTag(SpawnPointAITag);

        foreach (GameObject item in AIPoint)
        {
            int random = Random.Range(0, PrefabsAI.Count);
            if (alwaySpawn)
            {
                GameObject pts = Instantiate(PrefabsAI[random]);
                pts.transform.position = item.transform.position;
                pts.transform.rotation = item.transform.rotation;
            }
            else
            {
                int spawnOrNot = Random.Range(0, 2);
                if (spawnOrNot == 0)
                {
                    GameObject ptss = Instantiate(PrefabsAI[random]);
                    ptss.transform.position = item.transform.position;
                }
            }
        }
    }


    public void SpawnPaints()
    {
        GameObject[] PaintPoint = GameObject.FindGameObjectsWithTag(SpawnPointPaintsTag);

        foreach (GameObject item in PaintPoint)
        {
            int random = Random.Range(0, PrefabsPaints.Count);
            if (alwaySpawn)
            {
                GameObject pts = Instantiate(PrefabsPaints[random]);
                pts.transform.position = item.transform.position;
                pts.transform.rotation = item.transform.rotation;
            }
            else
            {
                int spawnOrNot = Random.Range(0, 2);
                if (spawnOrNot == 0)
                {
                    GameObject ptss = Instantiate(PrefabsPaints[random]);
                    ptss.transform.position = item.transform.position;
                }
            }
        }
    }

    IEnumerator timeScale()
    {
        int random = Random.Range(0, 15);
        yield return new WaitForSeconds(random);
        SpawnClock();
        SpawnSpeed();

    }    
}


     
