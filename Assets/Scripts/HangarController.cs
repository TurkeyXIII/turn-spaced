using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangarController : MonoBehaviour
{
    public List<GameObject> AllBlockSelectors;
    public GameObject BlocksContentPane;
    public GameObject RoomsContentPane;

    // Start is called before the first frame update
    void Start()
    {
        BlocksContentPane.GetComponent<BlockSelectorsContent>().SetBlockList(AllBlockSelectors);

        foreach (var selector in AllBlockSelectors)
        {
            Button button = selector.GetComponent<Button>();
            button.onClick.AddListener(() => OnSelectorClick(selector));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectorClick(GameObject selector)
    {
        Debug.Log("HangarController clicked");
    }
}
