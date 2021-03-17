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
        private bool isOn = false;

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
            var studentsDB = new StudentsDB();
            studentsDB.checkAllStudents(isOn);
            studentsDB.close();
            foreach(Transform child in SLListContent.transform)
            {
                var stInfoBlock = child.GetComponent<UserStudentBlock>();
                if (isOn) stInfoBlock.ToggleButton.SetOn();
                else stInfoBlock.ToggleButton.SetOff();
            }
        }
        public void AnalizeChecks()
        {
            bool AllChecks = true;
            foreach(Transform child in SLListContent.transform)
            {
                var stInfoBlock = child.GetComponent<UserStudentBlock>();
                if (!stInfoBlock.ToggleButton.GetIsOn()) AllChecks = false;
            }
            isOn = AllChecks;
            tickImage.gameObject.SetActive(isOn);
        }
    }
}