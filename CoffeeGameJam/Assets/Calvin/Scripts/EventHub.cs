using System;
using System.Collections.Generic;

namespace Assets.Scripts.Base.Events
{
	/// <summary>
	/// Large Scale Event Hub for mass event distribution
	/// </summary>
	public class EventHub : Singleton<EventHub>
	{
		private Dictionary<string, Action<DispatchableEvent>> delegates;
		private Dictionary<int, Dictionary<int, Action<DispatchableEvent>>> handlers;

		void Awake()
		{
			delegates = new Dictionary<string, Action<DispatchableEvent>>();
			handlers = new Dictionary<int, Dictionary<int, Action<DispatchableEvent>>>();
			SetInstance(this);
			DontDestroyOnLoad(this);
		}

		public void Subscribe<TEvent>(ISubscribable<TEvent> subscriber) where TEvent : DispatchableEvent
		{
			if (!handlers.ContainsKey(subscriber.GetHashCode()))
			{
				handlers.Add(subscriber.GetHashCode(), new Dictionary<int, Action<DispatchableEvent>>());
			}

			Action<DispatchableEvent> handler = (eventT) => subscriber.HandleEvent((TEvent)eventT);

			if (handlers[subscriber.GetHashCode()].TryAdd(typeof(TEvent).GetHashCode(), handler))
			{
				if (!delegates.ContainsKey(typeof(TEvent).Name))
				{
					delegates.Add(typeof(TEvent).Name, handlers[subscriber.GetHashCode()][typeof(TEvent).GetHashCode()]);
				}
				else
				{
					delegates[typeof(TEvent).Name] += handlers[subscriber.GetHashCode()][typeof(TEvent).GetHashCode()];
				}
			}
		}

		public void Unsubscribe<TEvent>(ISubscribable<TEvent> subscriber) where TEvent : DispatchableEvent
		{
			if (handlers.ContainsKey(subscriber.GetHashCode()))
			{
				if (handlers[subscriber.GetHashCode()].Remove(typeof(TEvent).GetHashCode(), out Action<DispatchableEvent> handler))
				{
					if (delegates.ContainsKey(typeof(TEvent).Name))
					{
						delegates[typeof(TEvent).Name] -= handler;
					}
				}
			}
		}

		public bool PostEvent<T>(T dispatchEvent) where T : DispatchableEvent
		{
			bool anyListeners = false;

			if (delegates.ContainsKey(typeof(T).Name))
			{
				anyListeners = delegates[typeof(T).Name] != null;
				delegates[typeof(T).Name]?.Invoke(dispatchEvent);
			}

			return anyListeners;
		}
	}

}
