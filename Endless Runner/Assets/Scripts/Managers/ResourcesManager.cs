using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent=null)
    {
        GameObject prefab = Load<GameObject>(path);

        if(prefab==null)
        {
            Debug.Log("Failed to Load Prfab : " + path);
            return null;
        }

        GameObject clone = Object.Instantiate(prefab, parent);

        int index = clone.name.IndexOf("(Clone)");//(Clone)을 만날 때 까지

        if (index>0)
        {
            clone.name = clone.name.Substring(0, index);
        }

        Debug.Log(clone.name);

        return clone;
    }
}