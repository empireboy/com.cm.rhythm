using System;

namespace CM.Rhythm
{
	public abstract class RhythmEntity<T>
	{
		public abstract float Time { get; }
		public abstract float TotalTime { get; }
		public abstract bool IsPlaying { get; }

		public float Duration { get; internal set; }

		protected T audio { get; }

		public RhythmEntity(T audio)
		{
			this.audio = audio;

			ResetDuration();
		}

		public void Play()
		{
			ResetDuration();
			OnPlay();
		}

		public void PlayAt(float time)
		{
			TimeExceptions(time);
			ResetDuration();
			OnPlayAt(time);
		}

		public void PlayAt(float time, float duration)
		{
			TimeExceptions(time);
			DurationExceptions(duration);

			Duration = duration;

			OnPlayAt(time);
		}

		public void Stop()
		{
			ResetDuration();
			OnStop();
		}

		protected abstract void OnPlay();
		protected abstract void OnPlayAt(float time);
		protected abstract void OnStop();

		private void ResetDuration()
		{
			Duration = 0;
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