using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class Kostil : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DelayKostil());
    }

    IEnumerator DelayKostil()
    {
        yield return new WaitForEndOfFrame();
        
        transform.GetChild(0).GetComponent<TMP_SelectionCaret>().raycastTarget = false;
    }
}
