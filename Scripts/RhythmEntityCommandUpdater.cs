namespace CM.Rhythm
{
	/// <summary>
	/// Executes all BeatCommand classes at corresponding times.
	/// </summary>
	public class RhythmEntityCommandUpdater
	{
		protected RhythmEntity Entity { get; }
		protected BeatCommand[] BeatCommands { get; }
		protected int BeatCommandIndex { get; private set; }

		/// <summary>
		/// Constructor for the RhythmEntityCommandUpdater.
		/// It takes in an array of BeatCommand.
		/// </summary>
		/// <param name="entity">The RhythmEntity that this updater uses.</param>
		/// <param name="beatCommands">The BeatCommand classes that need to be executed when the audio from RhythmEntity is playing.</param>
		public RhythmEntityCommandUpdater(RhythmEntity entity, BeatCommand[] beatCommands)
		{
			Entity = entity;
			BeatCommands = beatCommands;
			BeatCommandIndex = 0;
		}

		/// <summary>
		/// Executes the BeatCommand classes.
		/// This method should be called every frame.
		/// </summary>
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
		}
	}
}