using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour //MonoBehaviour를 상속 받은 클래스만 사용가능(제약 조건)
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
        set { }
    }

    protected virtual void Awake()
    {
        if(instance==null)
        {
            instance = (T)FindObjectOfType(typeof(T));
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}