using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPrefabs : MonoBehaviour
{
    public string KeyCore = "score_save";
    public int Score;

    private void Update()
    {
        //Save(MapController.instance.level, Score);
        //Load(MapController.instance.level);
    }

    public void Save ( int level, int score)
    {
        Debug.Log("Save level" + level + "" + score);
        PlayerPrefs.SetInt(KeyCore + level.ToString(), score);
        PlayerPrefs.Save();
    }

    public void Load( int level)
    {
        int ScoreLoaded = PlayerPrefs.GetInt(KeyCore + level.ToString());
        Debug.Log("Load level score: " + level + "" + ScoreLoaded);
    }
}
