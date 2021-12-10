using UnityEngine;

namespace CameraProject.Platformer
{
    public class PlayerController : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        private Transform _tr;

        [SerializeField] float _moveSpeed = 10;

        private void Awake() => _tr = transform;

        private void Update()
        {
            _tr.position += _tr.right * Input.GetAxis(HorizontalAxis) * _moveSpeed * Time.deltaTime;
        }
    }
}
