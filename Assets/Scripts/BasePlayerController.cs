using System.Collections;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))]
    public abstract class BasePlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerStatsComponent _playerStats; // сериализовала, чтобы для обоих PlayerController добыть все  параметры
        [SerializeField]
        protected Rigidbody _rigidbody; // избавилaсь от GetComponent

        protected float _jumpForce;
        protected float _forwardSpeed;
        protected float _sideSpeed;

        protected float _direction;

        protected virtual void Start()
        {
            _jumpForce = _playerStats.JumpForce;
            _forwardSpeed = _playerStats.ForwardSpeed;
            _sideSpeed = _playerStats.SideSpeed;
            StartCoroutine(MoveForward());
        }

        protected void Jump()
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse); // избавилaсь от GetComponent
        }

        private IEnumerator MoveForward()
        {
            while(true)
            {
                transform.position += transform.forward * _forwardSpeed * Time.deltaTime; // избавилaсь от GetComponent
                yield return null;
			}
		}
    }
}
