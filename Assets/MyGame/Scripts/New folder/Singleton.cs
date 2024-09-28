using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //DontDestroyOnLoad se duoc them vao cac class can thiet sau
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (FindObjectOfType<T>() != null)
                    instance = FindObjectOfType<T>();
                else
                    new GameObject().AddComponent<T>().name = "Singleton_" + typeof(T).ToString();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null && instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Debug.LogError("Singleton already exist " + instance.gameObject.name);
            Destroy(this.gameObject);
        }
        else
            instance = this.GetComponent<T>();
    }
}


