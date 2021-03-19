using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kostil : MonoBehaviour
{
    private void OnEnable()
    {
        transform.GetChild(0).GetComponent<TMP_SelectionCaret>().raycastTarget = false;
    }
}
