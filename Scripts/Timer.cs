using UnityEngine;

namespace CM.Timing
{
	/// <summary>
	/// Represents a delta time Unity timer that you can give a specific time in seconds.
	/// You need to manually Start/Stop this timer.
	/// </summary>
	public sealed class Timer : TimerBase
	{
		private static GameObject _updaterObject;

		private TimerUpdater _updater;

		/// <summary>
		/// Constructor for a timer with a TotalTime of zero.
		/// </summary>
		public Timer() : base()
		{

		}

		/// <summary>
		/// Constructor for a timer with a specified time in seconds.
		/// </summary>
		/// <param name="time">The time in seconds that this timer needs to run before finish.</param>
		public Timer(float time) : base(time)
		{

		}

		protected override void OnStart()
		{
			if (!_updaterObject)
				_updaterObject = new GameObject("Timer Container");

			if (!_updater)
				_updater = _updaterObject.AddComponent<TimerUpdater>();

			_updater.Initialize(this);
			_updater.Run();
		}

		protected override void OnStop()
		{
			if (!_updater)
				return;

			_updater.Stop();
		}

		internal void Finish()
		{
			InvokeOnFinish();
		}
	}
}