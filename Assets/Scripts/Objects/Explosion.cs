using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Animator))]
    public class Explosion : MonoBehaviour
    {
        private Animator _animator;
        private int _animaionNumber = 0;
        private float _animatioinTime = 1f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            StartCoroutine(PlayAnimationCoroutine());
        }

        private void OnDisable()
        {
            StopCoroutine(PlayAnimationCoroutine());
        }

        private IEnumerator PlayAnimationCoroutine()
        {
            _animator.Play(_animaionNumber);
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(_animaionNumber);

            while (stateInfo.normalizedTime < _animatioinTime)
            {
                stateInfo = _animator.GetCurrentAnimatorStateInfo(_animaionNumber);
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}