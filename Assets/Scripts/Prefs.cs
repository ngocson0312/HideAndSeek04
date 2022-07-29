using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Prefs
{
    public static int COIN
    {
        set
        {
            PlayerPrefs.SetInt(PreConsts.COIN_N, value);
        }
        get => PlayerPrefs.GetInt(PreConsts.COIN_N);
    }
    public static int LEVEL
    {
        set
        {
            PlayerPrefs.SetInt(PreConsts.LEVEL_L, value);
        }
        get => PlayerPrefs.GetInt(PreConsts.LEVEL_L);
    }
}
