using System.Collections.Generic;
using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "LevelWayPointsData", menuName = "LevelWayPoints", order = 0)]
    public class LevelWayPointsData : ScriptableObject
    {
        [Header("Level1 waypoints"), SerializeField] private List<Transform> _waypointsLevel1;
        [Header("Level2 waypoints"), SerializeField] private List<Transform> _waypointsLevel2;

        public List<Transform> WaypointsLevel1 => _waypointsLevel1;
        public List<Transform> WaypointsLevel2 => _waypointsLevel2;
    }
}