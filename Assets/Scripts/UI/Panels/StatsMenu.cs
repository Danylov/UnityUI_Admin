using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] private RectTransform statsMenuAll;
    [SerializeField] private StatsTeachersPanel statsMenuTeachers;
    [SerializeField] private StatsStudentsPanel statsMenuStudents;
    [SerializeField] private StatsTablePanel statsTable;
    [SerializeField] private StatsGeneralPanel statsGeneralPanel;
    
    public StatsGeneralPanel StatsGeneralPanel => statsGeneralPanel;
    private void CloseAllPanels()
    {
        statsMenuAll.gameObject.SetActive(false);
        statsMenuTeachers.ClosePanel();
        statsMenuStudents.ClosePanel();
        statsTable.ClosePanel();
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
        statsGeneralPanel.StatsGeneralVisualization();
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void OpenStatsMenuAll()
    {
        CloseAllPanels();
        statsMenuAll.gameObject.SetActive(true);
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