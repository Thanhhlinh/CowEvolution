using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private static Dictionary<string,List<Action>> Listeners = new Dictionary<string,List<Action>>();

    public static void AddObserver(string name , Action callBack)
    {
        if (!Listeners.ContainsKey(name))
        {
            Listeners.Add(name , new List<Action>());
        }
        Listeners[name].Add(callBack);
    }

    public static void RemoveObserver(string name, Action callBack) 
    {
        if (!Listeners.ContainsKey(name))
        {
            return;
        }
        Listeners[name].Remove(callBack);
    }

    public static void NotifyObservers(string name)
    {
        if (!Listeners.ContainsKey(name))
        {
            return;
        }
        foreach (var item in Listeners[name])
        {
            try
            {
                item?.Invoke();
            }catch (Exception e)
            {
                Debug.LogError("Error on invoke:"+e);
            }
        }
        
    }
}
