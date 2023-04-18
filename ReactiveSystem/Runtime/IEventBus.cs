using System;

namespace ReactiveSystem
{
    public interface IEventBus
    {
        public void Fire<T>(T signal) where T : struct;
        public void Subscribe<T>(Action<T> callback) where T : struct;
        public void UnSubscribe<T>(Action<T> callback) where T : struct;
        void UnsubscribeAll();
    }
}