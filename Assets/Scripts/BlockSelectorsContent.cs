using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSelectorsContent : MonoBehaviour
{
    private List<GameObject> _blockSelectors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBlockList(List<GameObject> blockSelectors)
    {
        _blockSelectors = blockSelectors;

        GameObject blockSelector = Instantiate(blockSelectors[0], transform);
        blockSelector.transform.localPosition = new Vector3(15, -15);
    }
}
