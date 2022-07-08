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
        private float speed;

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
            if (player.isFlipped)
            {
                var newCameraPos = _player.position.x - xOffset;
                var xPositionLerp = Mathf.Lerp(transform.position.x, newCameraPos, Time.deltaTime * speed);
                cameraPosition = new Vector3(xPositionLerp, cameraPosition.y, cameraPosition.z);
            }
            else
            {
                
                var newCameraPos =_player.position.x + xOffset;
                var xPositionLerp = Mathf.Lerp(transform.position.x, newCameraPos, Time.deltaTime * speed);
                cameraPosition = new Vector3(xPositionLerp, cameraPosition.y, cameraPosition.z);
            }

            cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX.position.x, maxX.position.x);
            cameraTransform.position = cameraPosition;
        }
    }
}
