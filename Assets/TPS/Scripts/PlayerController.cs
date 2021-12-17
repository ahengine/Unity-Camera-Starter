using UnityEngine;

namespace CameraProject.TPS
{
    public class PlayerController : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private Transform _tr;

        [SerializeField] float _moveSpeed = 10, _rotateSpeed = 10;

        private void Awake() => _tr = transform;

        private void Update()
        {
            _tr.position += _tr.forward * Input.GetAxis(VerticalAxis) * _moveSpeed * Time.deltaTime;
            _tr.Rotate(new Vector2(0, Input.GetAxis(HorizontalAxis) * _rotateSpeed * Time.deltaTime));
        }
    }
}
