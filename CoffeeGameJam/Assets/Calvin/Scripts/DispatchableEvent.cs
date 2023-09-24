using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Base.Events
{
	public class DispatchableEvent
	{
		public string EventName => this.GetType().Name;
	}
}
