using UnityEngine;

namespace CameraProject.TPS
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _target;
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
            if (Vector2.Distance(_tr.position, _target.position) > thresholdDistanceFollow)
                UpdateTargetPoint();

            _tr.position = Vector3.Lerp(_tr.position, _targetPoint, _moveSpeed*Time.deltaTime);
        }


        private void UpdateTargetPoint()
        {
            _targetPoint = new Vector3(_target.position.x, _target.position.y, _tr.position.z);
            _targetPoint += new Vector3(_offset.x, _offset.y);
        }
    }
}
