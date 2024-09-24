using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotationGameObject;

    private void OnEnable()
    {
        rotationGameObject = GameObject.Find("Rotation GameObject");

        speed = rotationGameObject.GetComponent<RotationGameObject>().Speed;

        transform.localRotation = rotationGameObject.transform.rotation;
    }
    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
