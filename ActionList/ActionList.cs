using System.Collections.Generic;
using System.Linq;

namespace ActionList
{
	public class ActionList
	{
		private readonly SortedList<int, IAction> _orderedActions;

		public ActionList()
		{
			_orderedActions = new SortedList<int, IAction>();
		}

		public int ActionCount
		{
			get { return _orderedActions.Count(); }
		}

		public void AddActions(IAction action)
		{
			var len = !_orderedActions.Any() ? 0 : _orderedActions.Count();
			if (action != null)
				_orderedActions.Add(len+1, action);
		}

		public void Update()
		{
			if (!_orderedActions.Any())
				return;
			bool blocked = false;
			for (int index = 0; index < _orderedActions.Count; index++)
			{
				var orderedAction = _orderedActions.ToArray()[index];
				if (blocked)
					continue;
				orderedAction.Value.Update();
				blocked = orderedAction.Value.IsBlocking;

				if (orderedAction.Value.IsFinished)
					_orderedActions.Remove(_orderedActions.First().Key);
			}
		}
	}
}