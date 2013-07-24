using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ActionList
{
	public class ActionList
	{
		private SortedList<int, IAction> _orderedActions;

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
	[TestFixture]
	public class ActionListTests
	{
		private ActionList _actionList;

		[Test]
		public void When_update_Then_one_less_action()
		{
			_actionList = new ActionList();
			_actionList.AddActions(new WalkTo());
			_actionList.AddActions(new WalkTo());
			_actionList.Update();
			Assert.AreEqual(1, _actionList.ActionCount);
		}
	}
}
