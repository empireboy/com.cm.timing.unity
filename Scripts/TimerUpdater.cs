using UnityEngine;

namespace CM.Timing
{
	/// <summary>
	/// Updates the Timer.
	/// This class will reduce the time of the Timer class using Time.deltaTime.
	/// </summary>
	public sealed class TimerUpdater : MonoBehaviour
	{
		private Timer _timer = null;
		private bool _isRunning = false;

		/// <summary>
		/// Initializes the TimerUpdater with a specified Timer that needs to be updated.
		/// </summary>
		/// <param name="timer">The Timer to update.</param>
		public void Initialize(Timer timer)
		{
			_timer = timer;
		}

		/// <summary>
		/// Starts updating the Timer.
		/// </summary>
		public void Run()
		{
			_isRunning = true;
		}

		/// <summary>
		/// Stops updating the Timer.
		/// </summary>
		public void Stop()
		{
			if (GetComponents<TimerUpdater>().Length == 1)
				Destroy(gameObject);

			Destroy(this);
		}

		private void Update()
		{
			if (!_isRunning)
				return;

			_timer.CurrentTime -= Time.deltaTime;

			if (_timer.CurrentTime <= 0)
			{
				_timer.Finish();
				Stop();
			}
		}
	}
}