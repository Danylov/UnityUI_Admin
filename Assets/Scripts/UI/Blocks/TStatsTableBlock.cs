using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TStatsTableBlock : MonoBehaviour
{
    [SerializeField] private StretchingList stretchingList;
    [SerializeField] private TextMeshProUGUI trainingNameText;
    [SerializeField] private TextMeshProUGUI trainingDateText;

    [SerializeField] private GameObject tStatsBlockStudentBlockPrefab;

    public void FillData()
    {
        
    }

    private void AddBlock()
    {
        //instantiate block and fill up data
    }
}
