using NUnit.Framework;

namespace ActionList
{
	[TestFixture]
	public class ActionListTests
	{
		private ActionList _actionList;

		[SetUp]
		public void Setup()
		{
			_actionList = CreateValidActionList();
		}

		[Test]
		public void When_update_Then_one_less_action()
		{
			_actionList.AddActions(new WalkTo(new Vector2(), new Vector2 { X = 1f }));
			_actionList.AddActions(new WalkTo(new Vector2(), new Vector2()));
			_actionList.Update();
			Assert.AreEqual(1, _actionList.ActionCount);
		}

		[Test]
		public void When_updatex2_Then_two_less_action()
		{
			_actionList.AddActions(new WalkTo(new Vector2 { X = 0.0f, Y = 0.01f }, new Vector2 { X = 1f }));
			_actionList.AddActions(new WalkTo(new Vector2 { X = 0.0f }, new Vector2 { X = 0f }));
			_actionList.Update();
			_actionList.Update();
			Assert.AreEqual(0, _actionList.ActionCount);
		}


		[Test]
		public void When_concurrent_actions_Then_they_step_at_the_same_time()
		{
			var concurrentAction1 = new NonBlockingAction() ;
			var concurrentAction2 = new NonBlockingAction() ;
			_actionList.AddActions(concurrentAction1);
			_actionList.AddActions(concurrentAction2);
			
			_actionList.Update();

			Assert.AreEqual(1,concurrentAction1.Steps);
			Assert.AreEqual(1,concurrentAction2.Steps);
		}

		[Test]
		public void When_faraway_then_not_finished()
		{
			_actionList.AddActions(new WalkTo(new Vector2(), new Vector2 { X = 100f }));

			_actionList.Update();

			Assert.AreEqual(1, _actionList.ActionCount);
		}

		[Test]
		public void When_finish_2x_nonblocking_use_sync_to_then_walk()
		{
			_actionList.AddActions(new NonBlockingAction());
			_actionList.AddActions(new NonBlockingAction());
			_actionList.AddActions(new SyncAction());
			_actionList.AddActions(new WalkTo(new Vector2(), new Vector2(){X = 10}));

			for (int i = 0; i < 20; i++)
			{
				_actionList.Update();
			}
		}

		private static ActionList CreateValidActionList()
		{
			return new ActionList();
		}
	}

	public class NonBlockingAction : IAction
	{
		public NonBlockingAction()
		{
			IsBlocking = false;
		}
		public bool IsFinished { get; private set; }
		public bool IsBlocking { get;  set; }
		public int Steps { get; set; }
		public void Update()
		{
			Steps++;
			if (Steps >= 10)
				IsFinished = true;
		}
	}
}
