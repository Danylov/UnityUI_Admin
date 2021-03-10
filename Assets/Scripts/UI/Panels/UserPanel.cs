using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPanel : MonoBehaviour
{
    
    [SerializeField] private Transform contentTransform;

    [SerializeField] private GameObject userBlockTeacherPrefab;
    [SerializeField] private GameObject userBlockStudentPrefab;

    private List<LabBlock> trackedBlocks = new List<LabBlock>();
    
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
    
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
