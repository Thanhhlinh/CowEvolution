using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData 
{
    public List<CowData> cows = new List<CowData>();
    public bool boughtCrate;
    public bool boughtBerryDelivery;
    public bool boughtEvolutionBar;
    public bool isAutoEvolveEnabled;
    public bool boughtMagnet;
    public float repeatInterval;
    public float timerSpawnTreeBerry;
    public float evolveInterval;
    public float maxEvolutionBar;
    public int coins;
    public int diamonds;
    public int highest_Tier;
    public int levelCrate;
    public int levelBerry;
    public int levelMagnet;
    public int levelEvolutionBar;
    public bool[] mission=GameManager.Instance.mission;
    /*public List<bool> mission = new List<bool>();*/
}
