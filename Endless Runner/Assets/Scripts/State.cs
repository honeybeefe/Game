using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] protected bool state=true;

    protected void OnEnable()
    {
        EventManager.Subscribe(EventType.START, OnExecute);
        EventManager.Subscribe(EventType.STOP, OnStop);
    }

    protected void OnExecute()
    {
        state = true;
    }

    protected void OnStop()
    {
        state = false;
    }

    protected void OnDisable()
    {
        EventManager.UnSubscribe(EventType.START, OnExecute);
        EventManager.UnSubscribe(EventType.STOP, OnStop);
    }
}
