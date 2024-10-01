using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum EventType
{
    START,
    CONTINUE,
    PAUSE,
    STOP
}

public class EventManager
{
    private static readonly IDictionary<EventType, UnityEvent> dictionary = new Dictionary<EventType, UnityEvent>();

    public static void Subscribe(EventType eventType, UnityAction listener)
    {
        UnityEvent unity;

        if(dictionary.TryGetValue(eventType, out unity))
        {
            unity.AddListener(listener);
        }
        else
        {
            unity = new UnityEvent();
            unity.AddListener(listener);
            dictionary.Add(eventType, unity);
        }
    }
}