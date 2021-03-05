using System.Collections;
using System.Collections.Generic;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class UnloadButton : MonoBehaviour
{
    public int studentDbId;
    public UserStudentBlock userStudentBlock; 
    [SerializeField] private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(UnloadButtonClick);   
    }
    private void UnloadButtonClick()
    {
        Debug.Log("UnloadButton.UnloadButtonClick()"); // Отладка
        Destroy(userStudentBlock.gameObject);
        var studentsDB = new StudentsDB();
        studentsDB.deleteStudentById(studentDbId);
        studentsDB.close();
    }
}
