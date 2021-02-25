using UnityEngine;

public class TaskPanel : MonoBehaviour
{
    [SerializeField] private RectTransform playListCreationMenu;
    [SerializeField] private RectTransform playListSelectionMenu;
    [SerializeField] private RectTransform panery3;
    [SerializeField] private RectTransform playlistChangeParametersMenu;
    [SerializeField] private RectTransform playlistChooseParticipantsMenu;
    [SerializeField] private RectTransform playlistDataBaseMenu;
    [SerializeField] private RectTransform playlistMpSetupMenu;

    private void CloseAllPanels()
    {
        playListCreationMenu.gameObject.SetActive(false);
        playListSelectionMenu.gameObject.SetActive(false);
        panery3.gameObject.SetActive(false);
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
        playlistChooseParticipantsMenu.gameObject.SetActive(true);
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

    public void OpenPaneru3Menu()
    {
        CloseAllPanels();
        panery3.gameObject.SetActive(true);
    }
}