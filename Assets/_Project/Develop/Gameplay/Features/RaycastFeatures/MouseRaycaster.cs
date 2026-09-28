using UnityEngine;

namespace _Project.Develop.Gameplay.Features.RaycastFeatures
{
    public class MouseRaycaster : MonoBehaviour
    {
        // References
        private IRaycaster _raycaster = null;
        private IShooter _shooter = null;

        private Ray _ray => _raycaster.GetRay();

        private void Awake()
            => _raycaster = new MousePointerRaycaster();

        public void SetShooter(IShooter shooter)
            => _shooter = shooter;

        public void Shoot()
            => _shooter.Shoot(_ray.origin, _ray.direction);
    }
}