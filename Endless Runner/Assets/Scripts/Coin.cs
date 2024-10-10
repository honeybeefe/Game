using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : State, IHitable
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotationGameObject;

    private new void OnEnable()
    {
        base.OnEnable();

        rotationGameObject = GameObject.Find("Rotation GameObject");

        speed = rotationGameObject.GetComponent<RotationGameObject>().Speed;

        transform.localRotation = rotationGameObject.transform.rotation;
    }
    private void Update()
    {
        if (state == false) return;

        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }
}