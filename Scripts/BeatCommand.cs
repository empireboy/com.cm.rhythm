using CM.Patterns.Command;

namespace CM.Rhythm
{
	public abstract class BeatCommand : Command
	{
		public float StartTime { get; private set; }

		public BeatCommand(float startTime)
		{
			StartTime = startTime;
		}

		public override void Execute()
		{
			throw new System.NotImplementedException();
		}

		public override void Undo()
		{
			throw new System.NotImplementedException();
		}
	}
}