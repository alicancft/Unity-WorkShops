using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alican
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Obstacle obstaclePrefab;
        [SerializeField] private ObstacleData placableObstacleData, destroyableObstacleData;

        [SerializeField] private bool willSpawnDestroyable = false;

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = FindWorldPos(Input.mousePosition);
                if (pos.HasValue)
                {
                    SpawnObstacle(pos.Value);
                }
            }
        }

        private Vector3? FindWorldPos(Vector2 inputCoords)
        {
            var ray = mainCamera.ScreenPointToRay(inputCoords);
            Vector3? worldPos = null;

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Floor")))
            {
                worldPos = hitInfo.point;
            }

            return worldPos;
        }

        private void SpawnObstacle(Vector3 pos)
        {
            var obstacle = Instantiate(obstaclePrefab);
            obstacle.transform.position = pos;
            obstacle.data = willSpawnDestroyable ? destroyableObstacleData : placableObstacleData;
            obstacle.Initialize();
        }
    }
}