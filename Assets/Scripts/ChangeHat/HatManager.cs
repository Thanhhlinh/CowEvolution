using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public static HatManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Dictionary<int, Hat> hatByLevel = new Dictionary<int, Hat>();

    public void SetHatForLevel(int level, Hat hat)
    {
        if (hatByLevel.ContainsKey(level))
        {
            hatByLevel[level] = hat;
        }
        else
        {
            hatByLevel[level] = hat;
        }
    }

    public Hat GetHatForLevel(int level)
    {
        hatByLevel.TryGetValue(level, out Hat hat);
        return hat;
    }

    public void RemoveHatForLevel(int level)
    {
        if (hatByLevel.ContainsKey(level))
        {
            hatByLevel.Remove(level);
        }
    }
}
