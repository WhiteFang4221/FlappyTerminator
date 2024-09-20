using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class PlaneTracker : MonoBehaviour
    {
        [SerializeField] private Plane _plane;
        [SerializeField] private float _xOffset;

        private void Update()
        {
            var position = transform.position;
            position.x = _plane.transform.position.x + _xOffset;
            transform.position = position;
        }
    }
}