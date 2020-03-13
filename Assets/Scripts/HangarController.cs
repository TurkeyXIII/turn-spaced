using System;
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

    public GameObject ShipUnderConstruction;

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

        if (Input.GetMouseButtonDown(MouseButton.LeftClick))
            AttemptToPlaceSelectedBlock();
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

        var construction = ShipUnderConstruction.GetComponent<Construction>();
        construction.ClearShadows();
    }

    private void AttemptToPlaceSelectedBlock()
    {
        if (_selectedBlock == null)
            return;

        var blockShadow = DetectShadowUnderMousePointer();

        if (blockShadow == null)
            return;

        var construction = ShipUnderConstruction.GetComponent<Construction>();
        //construction.ReplaceShadowWithBlock(blockShadow, _selectedBlock);
    }

    private BlockShadow DetectShadowUnderMousePointer()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics2D.RaycastAll(ray.origin, Vector2.zero);

        foreach (var hit in hits)
        {
            var blockShadow = hit.collider.GetComponent<BlockShadow>();
            if (blockShadow != null)
                return blockShadow;
        }

        return null;
    }

    public static HangarController GetHangarController()
    {
        return _hangarController;
    }

    public void SelectBlock(GameObject block)
    {
        if (_selectedBlock == null)
        {
            _selectedBlock = Instantiate(block);

            var construction = ShipUnderConstruction.GetComponent<Construction>();

            construction.CreateShadows(_selectedBlock.GetComponent<Block>());
        }
    }
}
