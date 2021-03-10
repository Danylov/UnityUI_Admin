using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTablePanel : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;

    [SerializeField] private GameObject statsTableBlockPrefab;
    
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private StatsTableBlock AddBlock()
    {
        var blockObject = Instantiate(statsTableBlockPrefab, contentTransform);
        StatsTableBlock block = blockObject.GetComponent<StatsTableBlock>();

        return block;
    }
}
