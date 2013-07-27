using System.Linq;

namespace ActionList
{
	public class SyncAction : IAction
	{
		private bool _atTop;
		private ActionList _actionList;
		public bool IsFinished { get; private set; }
		public bool IsBlocking { get; private set; }

		public SyncAction(ActionList actionList)
		{
			IsBlocking = true;
			_actionList = actionList;
		}

		public void Update()
		{
			if (_actionList.FirstOrDefault() == this)
				IsFinished = true;
		}
	}
}