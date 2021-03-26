using System;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{
    [SerializeField] private RectTransform playListCreationMenu;
    [SerializeField] private RectTransform playListSelectionMenu;
    [SerializeField] private RectTransform taskPanelMain;
    [SerializeField] private RectTransform playlistChangeParametersMenu;
    [SerializeField] private RectTransform playlistChooseParticipantsMenu;
    [SerializeField] private RectTransform playlistDataBaseMenu;
    [SerializeField] private RectTransform playlistMpSetupMenu;
    [SerializeField] private RectTransform SLListContentTP;

    [SerializeField] GameObject StudentSelectionBlockPrefab;
    
    [SerializeField] private ChangableButton navPoint1;
    [SerializeField] private ChangableButton navPoint2;

    private void CloseAllPanels()
    {
        playListCreationMenu.gameObject.SetActive(false);
        playListSelectionMenu.gameObject.SetActive(false);
        taskPanelMain.gameObject.SetActive(false);
        playlistChangeParametersMenu.gameObject.SetActive(false);
        playlistChooseParticipantsMenu.gameObject.SetActive(false);
        playlistDataBaseMenu.gameObject.SetActive(false);
        playlistMpSetupMenu.gameObject.SetActive(false);
    }

    public void OpenPlayListCreationMenu()
    {
        CloseAllPanels();
        playListCreationMenu.gameObject.SetActive(true);
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void OpenPlayListSelectionMenu()
    {
        CloseAllPanels();
        playListSelectionMenu.gameObject.SetActive(true);
    }

    public void OpenPlaylistChangeParametersMenu()
    {
        CloseAllPanels();
        playlistChangeParametersMenu.gameObject.SetActive(true);
    }

    public void OpenPlaylistChooseParticipantsMenu()
    {
        CloseAllPanels();
        navPoint1.SetInactiveSprite();
        navPoint2.SetActiveSprite();
        playlistChooseParticipantsMenu.gameObject.SetActive(true);
        SpawnStudentsTP();
    }

    public void OpenPlaylistDataBaseMenu()
    {
        CloseAllPanels();
        playlistDataBaseMenu.gameObject.SetActive(true);
    }

    public void OpenPlaylistMpSetupMenu()
    {
        CloseAllPanels();
        playlistMpSetupMenu.gameObject.SetActive(true);
    }

    public void OpenTaskPanelMainMenu()
    {
        CloseAllPanels();
        navPoint2.SetInactiveSprite();
        navPoint1.SetActiveSprite();
        taskPanelMain.gameObject.SetActive(true);
    }
    
    public void SpawnStudentsTP()
    {
        Debug.Log("SpawnStudentsTP()");  // Отладка
        foreach(Transform child in SLListContentTP.transform)   Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudentTP(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[8]));
            i++;
        }
        studentsDB.close();
    }

    
    private void SpawnStudentTP(int i, int id, string fullName, string organizType, string position, string persNumber, string login, int choosed)
    {
        Debug.Log("SpawnStudentTP(...): i = " + i);  // Отладка
        var spawnLocation = new Vector3(0, 2*i, 0);
        var studentSB = Instantiate(StudentSelectionBlockPrefab, spawnLocation, Quaternion.identity);
        studentSB.transform.SetParent(SLListContentTP.transform, false);
        var studentSelectionBlock = studentSB.GetComponent<StudentSelectionBlock>();
        studentSelectionBlock.NameText.text = fullName;
        studentSelectionBlock.PcText.text = "0";
    }

}