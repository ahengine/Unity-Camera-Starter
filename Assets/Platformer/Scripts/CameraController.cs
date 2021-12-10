using UnityEngine;

namespace CameraProject.Platformer
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _target;
        private float _targetLastPosX;
        private int _targetDir = 1;
        [SerializeField]private Vector3 _targetPoint;
        [SerializeField] float _moveSpeed = .1f, thresholdDistanceFollow = 4;
        [SerializeField] Vector2 _offset = new Vector2(2,2);

        private Transform _tr;

        private void Awake()
        {
            _tr = transform;
            UpdateTargetPoint();
        }

        private void LateUpdate()
        {
            // Target Updated Position
            if (_targetLastPosX != _target.position.x)
            {
                _targetDir = _targetLastPosX > _target.position.x ? -1 : 1;
                _targetLastPosX = _target.position.x;
            }


            if (Vector2.Distance(_tr.position, _target.position) > thresholdDistanceFollow)
                UpdateTargetPoint();

            _tr.position = Vector3.Lerp(_tr.position, _targetPoint, _moveSpeed*Time.deltaTime);
        }


        private void UpdateTargetPoint()
        {
            _targetPoint = new Vector3(_target.position.x, _target.position.y, _tr.position.z);
            _targetPoint += new Vector3(Mathf.Sign(_targetDir) * _offset.x, _offset.y);
        }
    }
}
