using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Immortality : MonoBehaviour
{
    [SerializeField] private Color _immortalityColor;
    private MeshRenderer _meshRenderer;
    private Color _baseColor;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _baseColor = _meshRenderer.material.color;
    }
    public void ActiveImmortality()
    {
        _meshRenderer.material.color = _immortalityColor;
    }
    public void DeactivateImmortality()
    {
        _meshRenderer.material.color = _baseColor;
    }

}
