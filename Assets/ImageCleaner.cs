using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageCleaner : MonoBehaviour
{
    [SerializeField] Sprite defaultSprite;

    [ContextMenu("CleanUpPanels")]
    private void CleanUpPanels()
    {
        GameObject[] gos = FindObjectsOfType<GameObject>();

        foreach (GameObject go in gos)
        {
            var bgSprite = go.GetComponent<Image>()?.sprite;

            if (bgSprite != null)
            {
                if (bgSprite == defaultSprite)
                {
                    GetComponent<Image>().sprite = null;

                    Debug.Log(go.name);
                }
            }
        }
        
        Debug.Log(gos.Length);
    }
}