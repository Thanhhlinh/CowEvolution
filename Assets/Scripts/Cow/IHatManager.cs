using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface cho quản lý mũ
public interface IHatManager
{
    void EquipHat(GameObject hatPrefab, int tier);
    void RemoveHat();
    void UpdateHatOnLevelChange(int level);
    GameObject GetCurrentHat();
}

public class CowHatManager : IHatManager
{
    private Transform hatPosition;
    private GameObject currentHat;

    public CowHatManager(Transform hatPosition, GameObject currentHat)
    {
        this.hatPosition = hatPosition;
        this.currentHat = currentHat;
    }

    public void EquipHat(GameObject hatPrefab, int tier)
    {
        RemoveHat();
        if (hatPrefab != null)
        {
            if (hatPosition.localScale == Vector3.one)
            {
                currentHat = GameObject.Instantiate(hatPrefab, hatPosition.position + GetHatPosition(tier), Quaternion.identity, hatPosition);
            }
            else
            {
                currentHat = GameObject.Instantiate(hatPrefab, hatPosition.position + new Vector3(-GetHatPosition(tier).x, GetHatPosition(tier).y, GetHatPosition(tier).z), Quaternion.identity, hatPosition);
            }

        }
    }

    public void RemoveHat()
    {
        if (currentHat != null)
        {
            GameObject.Destroy(currentHat);
            currentHat = null;
        }
    }
    public GameObject GetCurrentHat()
    {
        return currentHat;
    }

    private Vector3 GetHatPosition(int level)
    {
        return level switch
        {
            0 => new Vector3(0.13f, 0.2f, 0),
            1 => new Vector3(0.18f, 0.24f, 0),
            2 => new Vector3(0.12f, 0.26f, 0),
            3 => new Vector3(0.22f, 0.23f, 0),
            4 => new Vector3(0, 0.39f, 0),
            5 => new Vector3(0.03f, 0.42f, 0),
            6 => new Vector3(0, 0.36f, 0),
            7 => new Vector3(0, 0.5f, 0),
            8 => new Vector3(0.346f, 0.6f, 0),
            9 => new Vector3(0, 0.2f, 0),
            10 => new Vector3(0.16f, 0.6f, 0),
            11 => new Vector3(0, 0.5f, 0),
            12 => new Vector3(0, 0.24f, 0),
            13 => new Vector3(0, 0.6f, 0),
            14 => new Vector3(0, 0.65f, 0),
            15 => new Vector3(0.05f, 0.63f, 0),
            16 => new Vector3(0, 0.22f, 0),
            17 => new Vector3(0.34f, 0.55f, 0),
            _ => Vector3.zero
        };
    }

    public void UpdateHatOnLevelChange(int level)
    {
        Hat hat = HatManager.Instance.GetHatForLevel(level);
        if (hat != null && hat.hatPrefab != null)
        {
            EquipHat(hat.hatPrefab, level);
        }
    }
}
