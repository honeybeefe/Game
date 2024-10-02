using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum EventType // 이벤트 버스 시스템
{
    START,
    CONTINUE,
    PAUSE,
    STOP
}

public class EventManager // 이벤트 버스 시스템
{
    private static readonly IDictionary<EventType, UnityEvent> dictionary = new Dictionary<EventType, UnityEvent>();

    public static void Subscribe(EventType eventType, UnityAction unityAction)
    {
        UnityEvent unityEvent=null;

        if(dictionary.TryGetValue(eventType, out unityEvent))
        {
            unityEvent.AddListener(unityAction);
        }
        else
        {
            unityEvent = new UnityEvent();

            unityEvent.AddListener(unityAction);

            dictionary.Add(eventType, unityEvent);
        }
    }

    public static void UnSubscribe(EventType eventType, UnityAction unityAction) // 이벤트 버스 시스템
    {
        UnityEvent unityEvent = null;

        if (dictionary.TryGetValue(eventType, out unityEvent))
        {
            unityEvent.RemoveListener(unityAction);
        }
    }

    public static void Publish(EventType eventType)
    {
        UnityEvent unityEvent = null;

        if (dictionary.TryGetValue(eventType, out unityEvent))
        {
            unityEvent.Invoke();
        }
    }
}