﻿namespace FluentScheduler
{
    /// <summary>
    /// Unit of specific time of the day.
    /// </summary>
    public sealed class SpecificTimeUnit
    {
        internal SpecificTimeUnit(Schedule schedule)
        {
            Schedule = schedule;
        }

        internal Schedule Schedule { get; private set; }

        /// <summary>
        /// Also runs the job according to the given interval.
        /// </summary>
        /// <param name="interval">Interval to wait.</param>
        public TimeUnit AndEvery(int interval)
        {
            var parent = Schedule.Parent ?? Schedule;

            var child =
                new Schedule(Schedule.Jobs)
                {
                    Parent = parent,
                    Reentrant = parent.Reentrant,
                    Name = parent.Name
                };

            child.Parent.AdditionalSchedules.Add(child);
            return child.ToRunEvery(interval);
        }
    }
}
