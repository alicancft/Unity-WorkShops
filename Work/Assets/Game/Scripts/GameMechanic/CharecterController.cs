using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alican
{
    public class CharecterController : MonoBehaviour
    {
        [SerializeField] private Transform leftLimit, rightLimit, sideMovementRoot;
        [SerializeField] private float characterSpeed, sideMovementSpeed, MovementSensivity;
        private float leftLimitX => leftLimit.localPosition.x;
        private float rightLimitX => rightLimit.localPosition.x;
        private Vector2 inputDrag;
        private Vector2 previousMousePosition;
        private float sideMovementTarget = 0f;

        private Vector2 mousePositionCM
        {
            get
            {
                Vector2 pixels = Input.mousePosition;
                var inches = pixels / Screen.dpi;
                var centimeters = inches * 2.54f;
                return centimeters;
            }
        }


        void Update()
        {
            CharacterMovement();
            CharacterInput();
            CharacterSideMovement();
        }

        private void CharacterMovement()
        {
            transform.position += transform.forward * Time.deltaTime * characterSpeed;
        }

        private void CharacterSideMovement()
        {
            sideMovementTarget += inputDrag.x * sideMovementSpeed;
            sideMovementTarget = Mathf.Clamp(sideMovementTarget, leftLimitX, rightLimitX);

            var localPos = sideMovementRoot.localPosition;
            localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * MovementSensivity);
            sideMovementRoot.localPosition = localPos;
        }

        private void CharacterInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousMousePosition = mousePositionCM;
            }

            if (Input.GetMouseButton(0))
            {
                var deltaMouse = mousePositionCM - previousMousePosition;
                inputDrag = deltaMouse;
                previousMousePosition = mousePositionCM;
            }
            else
            {
                inputDrag = Vector2.zero;
            }
        }
    }
}