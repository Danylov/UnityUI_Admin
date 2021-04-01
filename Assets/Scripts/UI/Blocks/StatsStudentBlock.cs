using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class StatsStudentBlock : MonoBehaviour
{
    [SerializeField] private StretchingList stretchingList;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI groupText;
    
    [SerializeField] private ToggleButtonUser toggleButtonUser;
    [SerializeField] private UnloadButton unloadButton;

    [SerializeField] private GameObject trainingBlockPrefab;

    public TextMeshProUGUI NameText => nameText;
    public TextMeshProUGUI GroupText => groupText;
    public ToggleButtonUser ToggleButtonUser => toggleButtonUser;
    public UnloadButton UnloadButton => unloadButton;

    public void FillData()
    {
        
    }
    
    private void AddBlock()
    {
        //instantiate block and fill up data
    }
}
