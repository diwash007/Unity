using Enemy;
using PlayerScripts;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _player;

        [SerializeField]
        private Transform minX;
        [SerializeField]
        private Transform maxX;

        [SerializeField]
        private float xOffset;
        [SerializeField]
        private float speed = 5;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {
            if (!_player) return;
            if (!_player.TryGetComponent<Player>(out var player)) return;

            var cameraTransform = transform;
            var cameraPosition = cameraTransform.position;
            
            var newCameraPos = player.isFlipped ? _player.position.x - xOffset : _player.position.x + xOffset;

            if (player.isInPortal)
            {
                cameraPosition = new Vector3(newCameraPos, cameraPosition.y, cameraPosition.z);
                cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX.position.x, maxX.position.x);
            }
            else
            {
                var xPositionLerp = Mathf.Lerp(transform.position.x, newCameraPos, Time.deltaTime * speed);
                cameraPosition = new Vector3(xPositionLerp, cameraPosition.y, cameraPosition.z);
                cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX.position.x, maxX.position.x);
            }
            
            cameraTransform.position = cameraPosition; 
        }
    }
}
