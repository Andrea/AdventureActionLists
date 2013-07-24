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

			_orderedActions.First().Value.Update();
			_orderedActions.First().Value.IsFinished = true;
			_orderedActions.Remove(1);

		}
	}
}