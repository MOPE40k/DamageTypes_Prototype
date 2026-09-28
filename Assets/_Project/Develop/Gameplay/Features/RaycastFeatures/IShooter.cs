using UnityEngine;

namespace _Project.Develop.Gameplay.Features.RaycastFeatures
{
    public interface IShooter
    {
        void Shoot(Vector3 origin, Vector3 direction);
    }
}