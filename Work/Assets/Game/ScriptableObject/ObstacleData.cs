using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Alican
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Obstacle Data")]
    public class ObstacleData : ScriptableObject
    {
        public Material ObstacleMaterial;
        [TagField] public string ObstacleTag;
    }
}