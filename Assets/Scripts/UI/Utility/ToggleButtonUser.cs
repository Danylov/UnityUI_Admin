using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ToggleButtonUser : MonoBehaviour
    {
        [SerializeField] private bool isTeacher;
        [SerializeField] private Button button;
        [SerializeField] private Image tickImage;
        public ToggleAllButtons toggleAllButtons;
        
        public int userDbId;
        public bool isInGroup;
        private bool isOn;
        public Button Button => button;
        public bool IsOn => isOn;

        public void Start()
        {
            tickImage.gameObject.SetActive(isOn);
            button.onClick.AddListener(Switch);
        }

        private void Switch()
        {
            if (isInGroup)  return;
            isOn = !isOn;
            tickImage.gameObject.SetActive(isOn);

            if (isTeacher)
            {
                var teachersDB = new TeachersDB();
                teachersDB.checkTeacher(userDbId, isOn);
                teachersDB.close();
            } else {           
                var studentsDB = new StudentsDB();
                studentsDB.checkStudent(userDbId, isOn);
                studentsDB.close();
            }
            toggleAllButtons.AnalizeChecks();
        }
        
        public void SetState(bool isOn)
        {
            this.isOn = isOn;
            tickImage.gameObject.SetActive(isOn);
        }

        public void SetOn()
        {
            isOn = true;
            tickImage.gameObject.SetActive(isOn);
        }
        public void SetOff()
        {
            isOn = false;
            tickImage.gameObject.SetActive(isOn);
            toggleAllButtons.AnalizeChecks();
        }

        public bool GetIsOn()
        {
            return isOn;
        }
    }
}