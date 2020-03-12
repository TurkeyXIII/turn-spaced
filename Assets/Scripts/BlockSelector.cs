using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSelector : MonoBehaviour
{
    public GameObject Block;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(IveClickedMyself);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IveClickedMyself()
    {
        HangarController.GetHangarController().SelectBlock(Block);
    }
}
