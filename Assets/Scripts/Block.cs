using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject BlockShadow;

    private List<Doorway> _doorways;

    void Awake()
    {
        _doorways = GetComponentsInChildren<Doorway>().ToList();
    }

    public List<Vector3> GetViableRoomPositions()
    {
        var viableRoomPositions = new List<Vector3>();
        foreach (var doorway in _doorways)
        {
            var doorwayPositionFromBlock = doorway.transform.localPosition;
            var viableRoomPosition = transform.position + (2 * doorwayPositionFromBlock);

            viableRoomPositions.Add(viableRoomPosition);
        }

        return viableRoomPositions;
    }
}
