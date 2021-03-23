using System.Transactions;
using UnityEngine;

public class LauncherSettings
{
    private bool resetPanelStates = false;

    public bool ResetPanelStates
    {
        get => resetPanelStates;
        set => resetPanelStates = value;
    }

    private static LauncherSettings current = null;

    public static LauncherSettings Current
    {
        get
        {
            if (current == null)
            {
                current = new LauncherSettings();
            }

            return current;
        }
    }

    private LauncherSettings()
    {
    }
}