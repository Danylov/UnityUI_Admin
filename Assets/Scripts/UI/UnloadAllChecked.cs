using System.Collections;
using System.Collections.Generic;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class UnloadAllChecked : MonoBehaviour
{
    private GameObject SLListContent;
    [SerializeField] private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        SLListContent = GameObject.Find("SLListContent");
        button.onClick.AddListener(UnloadAllCheckedClick);   
    }
    private void UnloadAllCheckedClick()
    {
        var studentsDB = new StudentsDB();
        studentsDB.deleteCheckedStudents();
        studentsDB.close();
        foreach(Transform child in SLListContent.transform)
        {
            var userStudentBlock = child.GetComponent<UserStudentBlock>();
            if (userStudentBlock.ToggleButton.GetIsOn())  Destroy(userStudentBlock.gameObject);
        }
    }
}
