using CM.Timing;
using System;

namespace CM.Rhythm
{
	public abstract class RhythmEntity<T>
	{
		public abstract float Time { get; }
		public abstract float TotalTime { get; }
		public abstract bool IsPlaying { get; }

		protected T Audio { get; }

		private Timer _durationTimer = null;

		public RhythmEntity(T audio)
		{
			Audio = audio;
		}

		public void Play()
		{
			StopDurationTimer();
			OnPlay();
		}

		public void PlayAt(float time)
		{
			TimeExceptions(time);
			StopDurationTimer();
			OnPlayAt(time);
		}

		public void PlayAt(float time, float duration)
		{
			TimeExceptions(time);
			DurationExceptions(duration);

			// Create a new Timer if it doesn't exist.
			if (_durationTimer == null)
			{
				_durationTimer = new Timer();
				_durationTimer.OnFinish += OnDurationTimerFinish;
			}

			_durationTimer.TotalTime = duration;
			_durationTimer.Reset();
			_durationTimer.Start();

			OnPlayAt(time);
		}

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