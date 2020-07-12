using CM.Patterns.Command;

namespace CM.Rhythm
{
	/// <summary>
	/// Represents the base of a command that uses a specific time to execute.
	/// </summary>
	public abstract class BeatCommand : Command
	{
		/// <summary>
		/// The time in seconds to execute this command at.
		/// </summary>
		public float StartTime { get; private set; }

		/// <summary>
		/// Constructor for the BeatCommand.
		/// </summary>
		/// <param name="startTime">The time in seconds to execute this command at.</param>
		public BeatCommand(float startTime)
		{
			StartTime = startTime;
		}
	}
}