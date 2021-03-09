using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewsPanel : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;

    [SerializeField] private GameObject viewPrefab;

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
    
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}