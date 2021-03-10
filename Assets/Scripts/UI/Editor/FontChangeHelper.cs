using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontChangeHelper : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset newFont;

    [ContextMenu("Change")]
    public void Help()
    {
        var uguis = (TextMeshProUGUI[]) Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI));

        foreach (var ugui in uguis)
        {
            ugui.font = newFont;
        }
    }

    [SerializeField] private Sprite lfSpite;

    [ContextMenu("HadleToSliced")]
    public void HadleToSliced()
    {
        var uguis = (Image[]) Resources.FindObjectsOfTypeAll(typeof(Image));

        foreach (var ugui in uguis)
        {
            if (ugui.sprite != lfSpite)
                continue;

            ugui.type = Image.Type.Simple;

            ugui.sprite = null;

            ugui.color = new Color32(255, 255, 255, 128);
        }
    }
}