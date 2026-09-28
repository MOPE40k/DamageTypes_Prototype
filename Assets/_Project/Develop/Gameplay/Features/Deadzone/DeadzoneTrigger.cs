using UnityEngine;

namespace _Project.Develop.Gameplay.Features.Deadzone
{
  [RequireComponent(typeof(BoxCollider))]
  public class DeadzoneTrigger : MonoBehaviour
  {
    // References
    private Collider _collider = null;

    private void Awake()
    {
      _collider = GetComponent<Collider>();
      _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
        => Destroy(other.transform.root.gameObject);
  }
}