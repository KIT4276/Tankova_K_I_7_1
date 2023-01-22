using UnityEngine;

namespace Runner
{
    public class OldPlayerController : BasePlayerController
    {
        protected override void Start()
        {
            base.Start();
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();

            _direction = Input.GetAxis("Horizontal") * _sideSpeed * Time.fixedDeltaTime;// избавилaсь от GetComponent

            if (_direction == 0f) return;
            _rigidbody.velocity += _direction * transform.right;
        }
	}
}
