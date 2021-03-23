using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ToggleButtonUser : MonoBehaviour
    {
        private GameObject SLTickButton;
        private ToggleAllButtons toggleAllButtons;
        public int studentDbId;
        public bool isInGroup = false;
        [SerializeField] private Button button;
        public Button Button => button;
        [SerializeField] private Image tickImage;
        private bool isOn;
        public bool IsOn => isOn;

        public void Start()
        {
            SLTickButton = GameObject.Find("SLTickButton");
            toggleAllButtons = SLTickButton.GetComponent<ToggleAllButtons>();
            tickImage.gameObject.SetActive(isOn);
            button.onClick.AddListener(Switch);
        }

        private void Switch()
        {
            if (isInGroup)  return;

            isOn = !isOn;

            tickImage.gameObject.SetActive(isOn);
            var studentsDB = new StudentsDB();
            studentsDB.checkStudent(studentDbId, isOn);
            studentsDB.close();
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