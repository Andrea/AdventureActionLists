namespace ActionList
{
	public interface IAction
	{
		bool IsFinished { get; }
		bool IsBlocking { get; }
		
		void Update();
	}

	public class WalkTo : IAction
	{
		private readonly Vector2 _destination;
		private Vector2 _position;

		public bool IsFinished { get; private set; }
		public bool IsBlocking { get; private set; }
		
		public bool StartedUpdating { get; set; }
		public WalkTo(Vector2 origin, Vector2 destination, bool isBlocking = true)
		{
			_position = origin;
			_destination = destination;
			IsBlocking = isBlocking;
			StartedUpdating = false;
		}

		public void Update()
		{
			StartedUpdating = true;
			if (ArrivedDestination())
				IsFinished = true;
			else
				Move();
		}

		private void Move()
		{
			_position.X += 1;
		}

		private bool ArrivedDestination()
		{
			var diff = _destination.X - _position.X;
			return diff < 5;
		}
	}

	public struct Vector2
	{
		public float X { get; set; }
		public float Y { get; set; }
	}

}