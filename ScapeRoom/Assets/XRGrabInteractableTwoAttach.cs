using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    private Rigidbody rb; // Variável privada para armazenar o Rigidbody

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>(); // Inicializa o Rigidbody no Awake
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left hand"))
        {
            attachTransform = leftAttachTransform;
            Debug.Log("Usando o ponto de anexo da mão esquerda");
        }
        else if (args.interactorObject.transform.CompareTag("Right hand"))
        {
            attachTransform = rightAttachTransform;
            Debug.Log("Usando o ponto de anexo da mão direita");
        }

        // Desativa a física ao pegar o objeto
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log($"Posição do ponto de anexo: {attachTransform.position}");
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        // Reativa a física ao soltar o objeto
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        base.OnSelectExited(args);
    }
}
