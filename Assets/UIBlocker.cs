using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIBlocker : MonoBehaviour
{
    [SerializeField] private Button blockerButton;
    
    private static UIBlocker Instance;

    public static event UnityAction OnClick = null;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning($"More then one instance of {this.GetType()}");
            Destroy(gameObject);
        }
    }
}