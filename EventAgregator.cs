using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EventAgregator
{
    public interface IEventAgregator
    {
        void Publish<TMessageType>(TMessageType message);
        void Subscribe<TMessageType>(Action<TMessageType> action);
    }
    public sealed class EventAgregator : IEventAgregator
    {
        private static readonly EventAgregator instance = new EventAgregator();
        private readonly Dictionary<Type, IList> subscribers = new Dictionary<Type, IList>();
        public static EventAgregator Instance { get { return instance; } }

        static EventAgregator() { }
        private EventAgregator() { }

        public static void Publish<TMessageType>(TMessageType message)
        {
            Type type = typeof(TMessageType);

            foreach (Action<TMessageType> action in instance.subscribers[type].Cast<Action<TMessageType>>())
            {
                action.Invoke(message);
            }
        }

        public static void Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type type = typeof(TMessageType);

            if (instance.subscribers.ContainsKey(type))
            {
                instance.subscribers[type].Add(action);
            }
            else
            {
                var list = new List<Action<TMessageType>>() { action };
                instance.subscribers.Add(type, list);
            }
        }

        void IEventAgregator.Publish<TMessageType>(TMessageType message)
        {
            EventAgregator.Publish(message);
        }

        void IEventAgregator.Subscribe<TMessageType>(Action<TMessageType> action)
        {
            EventAgregator.Subscribe(action);
        }
    }
}
