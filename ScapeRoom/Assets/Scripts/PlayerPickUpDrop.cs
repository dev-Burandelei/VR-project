using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                float pickupDistance = 3f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, pickupDistance))
                {
                    if (hit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
