using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangarController : MonoBehaviour
{
    private static HangarController _hangarController;

    private GameObject _selectedBlock;

    public List<GameObject> AllBlockSelectors;
    public GameObject BlocksContentPane;
    public GameObject RoomsContentPane;

    private void Awake()
    {
        _hangarController = this;
        _selectedBlock = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        BlocksContentPane.GetComponent<BlockSelectorsContent>().SetBlockList(AllBlockSelectors);
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectedBlock != null)
            UpdateSelectedBlockToMousePosition();

        if (Input.GetMouseButtonUp(MouseButton.RightClick))
            DeselectBlock();
    }

    private void UpdateSelectedBlockToMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        _selectedBlock.transform.position = mousePosition;
    }

    private void DeselectBlock()
    {
        Destroy(_selectedBlock);
        _selectedBlock = null;
    }

    public static HangarController GetHangarController()
    {
        return _hangarController;
    }

    public void SelectBlock(GameObject block)
    {
        if (_selectedBlock == null)
            _selectedBlock = Instantiate(block);
    }
}
