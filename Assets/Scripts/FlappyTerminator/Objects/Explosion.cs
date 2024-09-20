using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Animator))]
    public class Explosion : MonoBehaviour
    {
        private Animator _animator;

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
            _animator.Play(0);
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.normalizedTime < 1.0f)
            {
                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                yield return null;
            }

            Debug.Log("Animation complete. Deactivating object.");
            gameObject.SetActive(false);
        }
    }
}