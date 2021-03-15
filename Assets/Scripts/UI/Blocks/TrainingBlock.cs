using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainingBlock : MonoBehaviour
{
    [SerializeField] private StretchingList stretchingList;
    
    [SerializeField] private TextMeshProUGUI trainingText;
    [SerializeField] private TextMeshProUGUI dateText;

    [SerializeField] private GameObject logBlockPrefab;
    
    public void FillData()
    {
        
    }

    private void AddBlock()
    {
        //instantiate block and fill up data
    }
}