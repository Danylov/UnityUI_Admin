using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPanel : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;

    [SerializeField] private GameObject labBlockPrefab;

    private List<LabBlock> trackedBlocks = new List<LabBlock>();
    
    private void ShowCaseMethod()
    {
        // fetch data from database
        
        // do it for each fetched student
        
        /*
        GameObject studentBlockGo = Instantiate(studentBlockPrefab, contentTransform);
        var studentBlock = studentBlockGo.GetComponent<LeftPanelStudentBlock>();

        studentBlock.SetData(-класс-модель-);
        */
    }
}
