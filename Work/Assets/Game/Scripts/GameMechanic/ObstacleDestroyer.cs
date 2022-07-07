using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alican
{
    public class ObstacleDestroyer : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var obj = FindHitObject(Input.mousePosition);
                if (obj != null)
                {
                    DestroyObstacle(obj);
                }
            }
        }

        private Collider FindHitObject(Vector2 inputCoords)
        {
            var ray = mainCamera.ScreenPointToRay(inputCoords);
            Collider obj = null;

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Obstacle")))
            {
                obj = hitInfo.collider;
            }

            return obj;
        }

        private void DestroyObstacle(Collider obj)
        {
            if (obj.gameObject.CompareTag("DestroyableObstacle"))
            {
                Destroy(obj.gameObject);
            }
        }
    }
}