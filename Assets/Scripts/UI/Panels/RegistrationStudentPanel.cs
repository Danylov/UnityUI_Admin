using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationStudentPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void Register()
    {
        MenuUIManager.Instance.SendPopup(5, "Успешная регистрация");
        StartCoroutine(DelayMenu(5f));
    }

    private IEnumerator DelayMenu(float time)
    {
        yield return new WaitForSeconds(time);

        MenuUIManager.Instance.OpenMainPanel();
    }
}
