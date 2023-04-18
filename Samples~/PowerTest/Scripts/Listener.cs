using UnityEngine;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public class Listener : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Instance.UnsubscribeAll();
            EventBus.Instance.Subscribe<PowerTestSignal>(OnSimpleSignal);
            EventBus.Instance.Subscribe<PowerTestParamSignal>(OnParamSignal);
            EventBus.Instance.Subscribe<PowerTestReferenceSignal>(OnReferenceSignal);
        }

        private void OnDisable()
        {
            EventBus.Instance.UnSubscribe<PowerTestSignal>(OnSimpleSignal);
            EventBus.Instance.UnSubscribe<PowerTestParamSignal>(OnParamSignal);
            EventBus.Instance.UnSubscribe<PowerTestReferenceSignal>(OnReferenceSignal);
        }

        private void OnParamSignal(PowerTestParamSignal obj)
        {
            
        }

        private void OnReferenceSignal(PowerTestReferenceSignal obj)
        {
            
        }

        private void OnSimpleSignal(PowerTestSignal obj)
        {
            
        }
    }
}