using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(ToggleButton))]
public class ToggleButtonEditor : Editor
{
    private SerializedProperty button;
    private SerializedProperty tickImage;

    private void OnEnable()
    {
        ToggleButton toggleButton = (ToggleButton) target;

        button = serializedObject.FindProperty("button");
        tickImage = serializedObject.FindProperty("tickImage");

        button.objectReferenceValue = toggleButton.gameObject.GetComponent<Button>();
        tickImage.objectReferenceValue = toggleButton.transform.GetChild(0).GetComponent<Image>();

        serializedObject.ApplyModifiedProperties();
    }
}