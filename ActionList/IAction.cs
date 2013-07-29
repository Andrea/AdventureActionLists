namespace ActionList
{
	public interface IAction
	{
		bool IsFinished { get; }
		bool IsBlocking { get; }
		
		void Update();
	}
}