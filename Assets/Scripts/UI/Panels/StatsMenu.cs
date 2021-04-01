using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] private StatsGeneralPanel statsMenuGeneral;
    [SerializeField] private StatsTeachersPanel statsMenuTeachers;
    [SerializeField] private StatsStudentsPanel statsMenuStudents;
    [SerializeField] private StatsTablePanel statsTable;
    
    private void CloseAllPanels()
    {
        statsMenuGeneral.ClosePanel();
        statsMenuTeachers.ClosePanel();
        statsMenuStudents.ClosePanel();
        statsTable.ClosePanel();
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
        OpenStatsMenuGeneral();
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void OpenStatsMenuGeneral()
    {
        CloseAllPanels();
        statsMenuGeneral.OpenPanel();
    }

    public void OpenStatsMenuTeachers()
    {
        CloseAllPanels();
        statsMenuTeachers.OpenPanel();
    }

    public void OpenStatsMenuStudents()
    {
        CloseAllPanels();
        statsMenuStudents.OpenPanel();
    }

    public void OpenStatsTable()
    {
        CloseAllPanels();
        statsTable.OpenPanel();
    }
}