using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ToggleAllButtons : MonoBehaviour
    {
        public GameObject SLListContent;
        [SerializeField] private Button button;
        [SerializeField] private Image tickImage;
        private int prefabType; // 0 - UserBlockTeacher, 1 - UserBlockStudent, 2 - StatsStudentBlock

        public int PrefabType
        {
            get => prefabType;
            set => prefabType = value;
        }

        private bool isOn;

        public bool IsOn => isOn;

        public void ToggleAllButtonsStart()
        {
            tickImage.gameObject.SetActive(isOn);
            button.onClick.AddListener(Switch);
        }

        private void Switch()
        {
            isOn = !isOn;
            tickImage.gameObject.SetActive(isOn);
            if (prefabType == 0)
            {
                var teachersDB = new TeachersDB();
                teachersDB.checkAllTeachers(isOn);
                teachersDB.close();
            } else {
                var studentsDB = new StudentsDB();
                studentsDB.checkAllStudents(isOn);
                studentsDB.close();
            }
            foreach(Transform child in SLListContent.transform)
            {
                ToggleButtonUser toggleButtonUser;
                switch (prefabType)
                {
                    case 0:  toggleButtonUser = child.GetComponent<UserBlockTeacher>().ToggleButtonUser; break;
                    case 1:  toggleButtonUser = child.GetComponent<UserBlockStudent>().ToggleButtonUser; break;
                    case 2:  toggleButtonUser = child.GetComponent<StatsStudentBlock>().ToggleButtonUser; break;
                    default: toggleButtonUser = child.GetComponent<UserBlockStudent>().ToggleButtonUser; break;
                }
                if (isOn) toggleButtonUser.SetOn();
                else toggleButtonUser.SetOff();
            }
            
        }
        public void AnalizeChecks()
        {
            if (prefabType == 0)
            {
                var teachersDB = new TeachersDB();
                isOn = teachersDB.isAllTeachersChoosed();
                teachersDB.close();
            } else {
                var studentsDB = new StudentsDB();
                isOn = studentsDB.isAllStudentsChoosed();
                studentsDB.close();
            }
            tickImage.gameObject.SetActive(isOn);
        }
    }
}