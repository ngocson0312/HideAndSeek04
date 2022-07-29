using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController instance;
    public int level;
    private void Awake()
    {
        instance = this;
    }
}
