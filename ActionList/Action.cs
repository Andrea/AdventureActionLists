namespace ActionList
{
	public interface IAction
	{
		 bool IsFinished { get; set; }

		void Update();
	}

	public class WalkTo : IAction
	{
		public bool IsFinished { get; set; }
		public void Update()
		{
				IsFinished = true;
		}
	}
}