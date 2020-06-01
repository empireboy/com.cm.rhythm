namespace CM.Rhythm
{
	public abstract class RhythmEntityUpdater<T>
	{
		protected abstract float Time { get; }

		protected RhythmEntity<T> Entity { get; }
		protected BeatCommand[] BeatCommands { get; }
		protected int BeatCommandIndex { get; }

		public RhythmEntityUpdater(RhythmEntity<T> entity)
		{
			Entity = entity;
			BeatCommandIndex = 0;
		}

		public void Update()
		{
			if (Entity.Duration != 0)
				UpdateDuration();

			OnUpdate();
		}

		protected abstract void OnUpdate();

		private void UpdateDuration()
		{
			Entity.Duration -= Time;

			if (Entity.Duration <= 0)
				Entity.Stop();
		}
	}
}