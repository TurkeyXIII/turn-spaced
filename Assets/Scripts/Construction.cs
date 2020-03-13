using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Construction : MonoBehaviour
{
    private List<Block> _compositeBlocks;
    private List<BlockShadow> _currentShadows;

    // Start is called before the first frame update
    void Start()
    {
        _compositeBlocks = transform.GetComponentsInChildren<Block>().ToList();
        _currentShadows = new List<BlockShadow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateShadows(Block blockPrefab)
    {
        var shadowPrefab = blockPrefab.BlockShadow;

        List<Vector3> viableRoomPositions = _compositeBlocks.SelectMany(b => b.GetViableRoomPositions())
            .Distinct() //Vector3s are probably not unique enough to filter dupes like this
            .ToList();

        foreach (var viableRoomPosition in viableRoomPositions)
        {
            var shadow = Instantiate(shadowPrefab, transform).GetComponent<BlockShadow>();
            shadow.transform.position = viableRoomPosition;

            _currentShadows.Add(shadow);
            shadow.Construction = this;
        }
    }

    public void ClearShadows()
    {
        foreach (var shadow in _currentShadows)
        {
            Destroy(shadow.gameObject);
        }

        _currentShadows.Clear();
    }

    public void ConstructBlockAtPosition(Block block, Vector3 position)
    {
        ClearShadows();

        var constructedBlock = Instantiate(block.gameObject, transform).GetComponent<Block>();
        constructedBlock.transform.position = position;
        _compositeBlocks.Add(constructedBlock);

        CreateShadows(block);
    }
}
