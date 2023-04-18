using UnityEngine;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public class CubeListener : MonoBehaviour
    {
        private Material material;
        private void Awake()
        {
            material = GetComponent<MeshRenderer>().material;
            EventBus.Instance.Subscribe<CubeActionSignal>(ChangeColor);
        }

        private void ChangeColor(CubeActionSignal obj)
        {
            if(material != null)
                material.color = obj.Color;
        }
    }
}