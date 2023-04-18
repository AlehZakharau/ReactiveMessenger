using System;
using UnityEngine;

namespace ReactiveSystem.Example
{
    public class SimpleListener : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Instance.Subscribe<MessageSignal>(obj => Debug.Log(obj.Message));
            EventBus.Instance.Subscribe<MessageSignal>(OnMessageArrived);
        }

        private void OnMessageArrived(MessageSignal obj)
        {
            Debug.Log(obj.Message);
        }

        private void OnDisable()
        {
            EventBus.Instance.UnSubscribe<MessageSignal>(obj => Debug.Log(obj.Message));
            EventBus.Instance.UnSubscribe<MessageSignal>(OnMessageArrived);
        }
    }
}