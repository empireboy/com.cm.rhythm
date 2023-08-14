using CM.Timing;
using System;

namespace CM.Rhythm
{
	/// <summary>
	/// Represents the base of an audio player.
	/// </summary>
	public abstract class RhythmEntity
	{
		/// <summary>
		/// The current time in seconds of the audio.
		/// </summary>
		public abstract float Time { get; }

		/// <summary>
		/// The total time in seconds of the audio.
		/// </summary>
		public abstract float TotalTime { get; }

		/// <summary>
		/// True if the audio is playing.
		/// </summary>
		public abstract bool IsPlaying { get; }

		private Timer _durationTimer = null;

		/// <summary>
		/// Plays the audio from the beginning.
		/// </summary>
		public void Play()
		{
			StopDurationTimer();
			OnPlay();
		}

		/// <summary>
		/// Plays the audio at a specific time.
		/// </summary>
		/// <param name="time">Time to play the audio at in seconds.</param>
		public void PlayAt(float time)
		{
			TimeExceptions(time);
			StopDurationTimer();
			OnPlayAt(time);
		}

		/// <summary>
		/// Plays the audio at a specific time for a specific duration.
		/// </summary>
		/// <param name="time">Time to play the audio at in seconds.</param>
		/// <param name="duration">The duration to play the audio for in seconds.</param>
		public void PlayAt(float time, float duration)
		{
			TimeExceptions(time);
			DurationExceptions(duration);

			// Create a new Timer if it doesn't exist.
			if (_durationTimer == null)
			{
				_durationTimer = new Timer();
				_durationTimer.OnFinished += OnDurationTimerFinish;
			}

			_durationTimer.TotalTime = duration;
			_durationTimer.Reset();
			_durationTimer.Start();

			OnPlayAt(time);
		}

		/// <summary>
		/// Stops the audio.
		/// </summary>
		public void Stop()
		{
			StopDurationTimer();
			OnStop();
		}

		protected abstract void OnPlay();
		protected abstract void OnPlayAt(float time);
		protected abstract void OnStop();

		private void StopDurationTimer()
		{
			if (_durationTimer == null)
				return;

			_durationTimer.Stop();
		}

		private void OnDurationTimerFinish()
		{
			_durationTimer = null;
			Stop();
		}

		private void TimeExceptions(float time)
		{
			if (time < 0)
				throw new ArgumentException("PlayAt time can't be less than zero.");

			if (time > TotalTime)
				throw new ArgumentException("PlayAt time can't be greater than the total time of the audio.");
		}

		private void DurationExceptions(float duration)
		{
			if (duration <= 0)
				throw new ArgumentException("PlayAt duration can't be equal or less than zero.");
		}
	}
}