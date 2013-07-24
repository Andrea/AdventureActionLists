using NUnit.Framework;

namespace ActionList
{
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
