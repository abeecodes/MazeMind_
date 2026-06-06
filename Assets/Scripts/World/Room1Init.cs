using UnityEngine;
using MazeMind.Core;

public class Room1Init : MonoBehaviour
{
    void Start()
    {
        // Tell PlayerMetrics how big this room is
        // 220 walkable tiles, 4 gems total
        if (PlayerMetrics.I != null)
        {
            PlayerMetrics.I.ConfigureRoom(
                totalWalkableTiles: 220,
                gemsAvailable: 4
            );
        }
    }
}