using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactiveSystem
{
    public class EventBus : IEventBus
    {
        private static EventBus instance;

        public static EventBus Instance => instance ??= new EventBus();
        
        private readonly Dictionary<Type, ISubscriber> delegates = new();

#if EVENTBUS_LOG
        private readonly EventBusLogger eventBusLogger = new();
#endif
        public void Fire<T>(T signal) where T : struct
        {
#if EVENTBUS_LOG
            eventBusLogger.FireLog(signal);
#endif
            if (delegates.TryGetValue(typeof(T), out var subscribers))
            {
                var list = (Subscriber<T>)subscribers;
                var saveCopy = list.Callbacks.ToList();
                foreach (var action in saveCopy)
                {
                    action(signal);
                }
            }
        }

        public void Subscribe<T>(Action<T> callback) where T : struct
        {
            var type = typeof(T);
            if (!delegates.TryGetValue(type, out var subscribers))
            {
                subscribers = new Subscriber<T>();
                delegates[type] = subscribers;
            }
            var list = (Subscriber<T>)subscribers;
            list.Callbacks.Add(callback);
#if EVENTBUS_LOG
            eventBusLogger.SubscribeLog(callback, list.Callbacks.Count);
#endif
        }

        public void UnSubscribe<T>(Action<T> callback) where T : struct
        {
            var type = typeof(T);
            if (delegates.ContainsKey(type))
            {
                var callbacks = (Subscriber<T>)delegates[type];{}
                //var call = callbacks.Callbacks.FirstOrDefault(c => c == callback);
                callbacks.Callbacks.Remove(callback);
#if EVENTBUS_LOG
                eventBusLogger.UnSubscribeLog(callback, callbacks.Callbacks.Count);
#endif
                if (callbacks.Callbacks.Count == 0)
                {
                    delegates.Remove(type);
                }
            }
        }

        public void UnsubscribeAll()
        {
            delegates.Clear();
        }
    }
}