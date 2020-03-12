using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Construction : MonoBehaviour
{
    private List<Block> _compositeBlocks;
    private List<GameObject> _currentShadows;

    // Start is called before the first frame update
    void Start()
    {
        _compositeBlocks = transform.GetComponentsInChildren<Block>().ToList();
        _currentShadows = new List<GameObject>();
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
            GameObject shadow = Instantiate(shadowPrefab, transform);
            shadow.transform.position = viableRoomPosition;

            _currentShadows.Add(shadow);
        }
    }

    public void ClearShadows()
    {
        foreach (var shadow in _currentShadows)
        {
            Destroy(shadow);
        }

        _currentShadows.Clear();
    }
}
