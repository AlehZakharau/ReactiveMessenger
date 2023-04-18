using System;
using System.Collections.Generic;

namespace ReactiveSystem
{
    public interface ISubscriber
    {
        
    }
    
    public class Subscriber<T> : ISubscriber
    {
        public List<Action<T>> Callbacks { get; } = new();
    }
}