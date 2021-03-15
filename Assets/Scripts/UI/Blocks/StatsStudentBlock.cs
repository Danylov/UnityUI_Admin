using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsStudentBlock : MonoBehaviour
{
    [SerializeField] private StretchingList stretchingList;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI groupText;

    [SerializeField] private GameObject trainingBlockPrefab;

    public void FillData()
    {
        
    }
    
    private void AddBlock()
    {
        //instantiate block and fill up data
    }
}
