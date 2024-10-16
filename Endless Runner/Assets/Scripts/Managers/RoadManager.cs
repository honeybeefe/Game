using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : State
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed = 50.0f;
    [SerializeField] float offset = 40.0f;

    void Start()
    {
        roads.Capacity = 10;
    }

    void Update()
    {
        if (state == false) return;

        for (int i=0; i<roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void  InitializePosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);

        float newZ = roads[roads.Count-1].transform.position.z + offset;

        newRoad.transform.position =new Vector3(0, 0, newZ);

        roads.Add(newRoad);
    }
}