using System;
using UnityEngine;

namespace ReactiveSystem.Example
{
    public struct MessageSignal
    {
        public string Message;
        public MessageSignal(string message)
        {
            Message = message;
        }
    }
    public class SimpleStart : MonoBehaviour
    {
        private void Start()
        {
            EventBus.Instance.Fire(new MessageSignal("Hello world"));
        }
        public void FireSignal(string message)
        {
            EventBus.Instance.Fire(new MessageSignal(message));
        }
    }
}