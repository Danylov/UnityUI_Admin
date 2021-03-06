﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class LabBlock : MonoBehaviour
{
    public int taskId;
    public ToggleButton toggleButton;
    [SerializeField] private Button changeParametersButton;
    [SerializeField] private TextMeshProUGUI labCodeText;
    [SerializeField] private TextMeshProUGUI labDescText;
    [SerializeField] private TextMeshProUGUI parametersChangedText;
    public TextMeshProUGUI LabCodeText => labCodeText;
    public TextMeshProUGUI LabDescText => labDescText;
    public TextMeshProUGUI ParametersChangedText => parametersChangedText;
}
