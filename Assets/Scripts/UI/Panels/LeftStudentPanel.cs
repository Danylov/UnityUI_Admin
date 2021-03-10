using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LeftStudentPanel : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;

    [SerializeField] private GameObject studentBlockPrefab;

    private List<LeftPanelStudentBlock> trackedBlocks = new List<LeftPanelStudentBlock>();
    
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
