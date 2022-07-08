using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _player;
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
            if (!_player.TryGetComponent<Player.Player>(out var player)) return;

            var cameraTransform = transform;
            var cameraPosition = cameraTransform.position;
            if (player.isFlipped)
            {
                var xPositionLerp = Mathf.Lerp(transform.position.x, _player.position.x - xOffset, Time.deltaTime * speed);
                cameraPosition = new Vector3(xPositionLerp, cameraPosition.y, cameraPosition.z);
            }
            else
            {
                var xPositionLerp = Mathf.Lerp(transform.position.x, _player.position.x + xOffset, Time.deltaTime * speed);
                cameraPosition = new Vector3(xPositionLerp, cameraPosition.y, cameraPosition.z);
            }
            cameraTransform.position = cameraPosition; 
        }
    }
}
