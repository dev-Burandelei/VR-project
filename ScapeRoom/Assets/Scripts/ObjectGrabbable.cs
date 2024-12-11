using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    [SerializeField] private Material defaultMaterial;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    public void Highlight(bool state)
    {

        if (state)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material = defaultMaterial;
        }
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float grabSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * grabSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
