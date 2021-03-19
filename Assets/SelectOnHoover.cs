using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnHoover : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private TMP_InputField refInputField;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!refInputField.readOnly)
        {
            refInputField.ActivateInputField();
            refInputField.Select();
        }
    }
}
