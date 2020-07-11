namespace CM.Rhythm
{
	public class RhythmEntityCommandUpdater<T>
	{
		protected RhythmEntity<T> Entity { get; }
		protected BeatCommand[] BeatCommands { get; }
		protected int BeatCommandIndex { get; private set; }

		public RhythmEntityCommandUpdater(RhythmEntity<T> entity, BeatCommand[] beatCommands)
		{
			Entity = entity;
			BeatCommands = beatCommands;
			BeatCommandIndex = 0;
		}

		public void Update()
		{
			if (BeatCommands == null)
				return;

			if (BeatCommandIndex >= BeatCommands.Length)
				return;

			if (Entity.Time >= BeatCommands[BeatCommandIndex].StartTime)
			{
				BeatCommands[BeatCommandIndex].Execute();
				BeatCommandIndex++;
			}

			OnUpdate();
		}

		protected virtual void OnUpdate()
		{

		}
	}
}