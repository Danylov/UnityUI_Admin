using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ToggleButton : MonoBehaviour
    {
        public bool isInGroup;
        [SerializeField] private Button button;
        public Button Button => button;
        [SerializeField] private Image tickImage;
        private bool isOn;
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
        }
        
        public void SetState(bool isOn)
        {
            this.isOn = isOn;
            tickImage.gameObject.SetActive(isOn);
        }
    }
}