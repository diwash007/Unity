using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _player;
        private Vector3 _tempPos;

        [SerializeField]
        private float minX, maxX;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            if (!_player) return;
        
            _tempPos = transform.position;
            _tempPos.x = _player.position.x + 3;

            if (_tempPos.x < minX) _tempPos.x = minX;
            if (_tempPos.x > maxX) _tempPos.x = maxX;
        
            transform.position = _tempPos;
        }
    }
}
