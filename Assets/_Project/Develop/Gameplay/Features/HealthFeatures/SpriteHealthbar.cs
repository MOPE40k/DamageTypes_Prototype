using UnityEngine;

namespace _Project.Develop.Gameplay.Features.HealthFeatures
{
    public class SpriteHealthBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _filler;
        [SerializeField] private Color _fullHealthColor = Color.green;
        [SerializeField] private Color _emptyHealthColor = Color.red;
        
        private MaterialPropertyBlock _propertyBlock;

        private static readonly int FillAmountID = Shader.PropertyToID("_FillAmount");
        private static readonly int ColorID = Shader.PropertyToID("_Color");
        private static readonly int EmptyColorID = Shader.PropertyToID("_EmptyColor");

        private void Awake()
        {
            EnsureInitialized();
        }
        
        private void EnsureInitialized()
        {
            _propertyBlock ??= new MaterialPropertyBlock();
        }
        
        public void SetHealth(float currentHealth, float maxHealth)
        {
            EnsureInitialized();
            
            float fillAmount = Mathf.Clamp01(currentHealth / maxHealth);

            _filler.GetPropertyBlock(_propertyBlock);

            _propertyBlock.SetFloat(FillAmountID, fillAmount);
            _propertyBlock.SetColor(ColorID, _fullHealthColor);
            _propertyBlock.SetColor(EmptyColorID, _emptyHealthColor);

            _filler.SetPropertyBlock(_propertyBlock);
        }
    }
}