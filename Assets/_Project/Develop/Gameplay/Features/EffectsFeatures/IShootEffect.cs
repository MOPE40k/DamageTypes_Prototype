using UnityEngine;

namespace _Project.Develop.Gameplay.Features.EffectsFeatures
{
    public interface IShootEffect
    {
        void Execute(Vector3 point, Collider collider);
    }
}