/*****************************************************************************
// File Name :         Singleton.cs
// Author :            Owen Schaffer
// Creation Date :     10/28/2020
//
// Brief Description : Generic Singleton script
*****************************************************************************/
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }

    public static bool isInitialized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a second instance of a singleton class.");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        //If this object is destroyed, make instance null so another one can be created.
        if (instance == this)
        {
            instance = null;
        }
    }
}