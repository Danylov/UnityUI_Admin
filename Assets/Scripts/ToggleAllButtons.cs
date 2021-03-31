using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ToggleAllButtons : MonoBehaviour
    {
        [SerializeField] private GameObject SLListContent;
        [SerializeField] private Button button;
        [SerializeField] private Image tickImage;
        private bool isTeacher;
        private bool isOn;

        public bool IsTeacher
        {
            get => isTeacher;
            set => isTeacher = value;
        }

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
            if (isTeacher)
            {
                var teachersDB = new TeachersDB();
                teachersDB.checkAllTeachers(isOn);
                teachersDB.close();
                foreach(Transform child in SLListContent.transform)
                {
                    var stInfoBlock = child.GetComponent<UserBlockTeacher>();
                    if (isOn) stInfoBlock.ToggleButtonUser.SetOn();
                    else stInfoBlock.ToggleButtonUser.SetOff();
                }
            
            } else {
                var studentsDB = new StudentsDB();
                studentsDB.checkAllStudents(isOn);
                studentsDB.close();
                foreach(Transform child in SLListContent.transform)
                {
                    var stInfoBlock = child.GetComponent<UserBlockStudent>();
                    if (isOn) stInfoBlock.ToggleButtonUser.SetOn();
                    else stInfoBlock.ToggleButtonUser.SetOff();
                }
            }
            
        }
        public void AnalizeChecks()
        {
            if (isTeacher)
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