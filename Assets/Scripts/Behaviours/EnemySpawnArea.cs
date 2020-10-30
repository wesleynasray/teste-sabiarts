using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnArea : SpawnArea
{
    [SerializeField] Transform[] waypoints = { };

    public override GameObject Spawn()
    {
        var spawn = base.Spawn();
        
        var waypointMove = spawn.GetComponent<WaypointMove>();
        waypointMove.points = waypoints;
        
        return spawn;
    }
}
