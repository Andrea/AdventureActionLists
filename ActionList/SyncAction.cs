namespace ActionList
{
	public class SyncAction : IAction
	{
		private bool _atTop;
		public bool IsFinished { get; private set; }
		public bool IsBlocking { get; private set; }
		

		public void Update()
		{
			if (_atTop)
				IsFinished = true;
		}

		public void SetAsTopOfList()
		{
			_atTop = true;
		}
	}
}