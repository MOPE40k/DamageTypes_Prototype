using UnityEngine;

namespace _Project.Develop.Gameplay.Features.AnimationFeatures
{
    public class InteractObjectAnimationController : MonoBehaviour
    {
        // Consts
        private int InteractTriggerKey => Animator.StringToHash("Interact");

        [Header("References:")]
        [SerializeField] private Animator _animator = null;

        public void InteractableAnimation()
        {
            if (_animator)
                _animator.SetTrigger(InteractTriggerKey);
        }
    }
}