using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class StatsTableBlock : MonoBehaviour
{
    public ToggleButton ToggleButton;

    [SerializeField] private TextMeshProUGUI teacherNameText;
    [SerializeField] private TextMeshProUGUI studentNameText;
    [SerializeField] private TextMeshProUGUI groupText;
    [SerializeField] private TextMeshProUGUI labNameText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI dateText;
}