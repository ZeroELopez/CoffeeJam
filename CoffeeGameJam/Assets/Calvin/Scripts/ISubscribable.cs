using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Base.Events
{
	public interface ISubscribable<TEvent> where TEvent : DispatchableEvent
	{
		void Subscribe();
		void Unsubscribe();
		void HandleEvent(TEvent evt);
	}
}