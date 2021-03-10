using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpBlock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI labText;
    [SerializeField] private Button helpButton;

    public TextMeshProUGUI LabText => labText;


    public Button HelpButton => helpButton;
}