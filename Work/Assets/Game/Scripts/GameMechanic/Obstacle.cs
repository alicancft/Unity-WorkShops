using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alican
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private Renderer obstacleRenderer;
        public ObstacleData data;

        public void Initialize()
        {
            obstacleRenderer.gameObject.tag = data.ObstacleTag;
            obstacleRenderer.sharedMaterial = data.ObstacleMaterial;
        }
    }
}