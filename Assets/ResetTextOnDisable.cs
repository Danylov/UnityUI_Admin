using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class ResetTextOnDisable : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void OnDisable()
    {
        if (!inputField)
            inputField = GetComponent<TMP_InputField>();
        
        inputField.text = string.Empty;
    }
}
