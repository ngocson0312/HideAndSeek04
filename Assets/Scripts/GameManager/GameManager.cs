using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;
    public MapData[] mapDatas;
    [SerializeField] GameObject canvasMainUI;
    public bool isPlayGame =false;
    public bool zoomCam = false;

    public int level;
    private void Awake()
    {
        instance = this;
        cam.depth = 1;
    }


    public void Cam ()
    {
        isPlayGame = true;
        cam.depth = -1;
        canvasMainUI.SetActive(false);
        zoomCam = true;
    }
    public void PlayGame()
    {

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))// đây là nút nextlevel (win)
        {
            GameManager.instance.level++;
            GameManager.instance.level = Prefs.LEVEL;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Level: " + GameManager.instance.level);
        }

    }

}
