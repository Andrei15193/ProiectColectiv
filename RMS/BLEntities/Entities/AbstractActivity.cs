using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractActivity : IDateTimeBound
    {
        public int Id { get;  set; }

        public ActivityType Type { get; private set; }

        public virtual State State { get; set; }

        public string Title { get; private set; }

        public string Description { get; set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        protected AbstractActivity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate, int id)
        {
            if (title != null)
                if (description != null)
                    if (title.Length > 0)
                        if (startDate < endDate)
                        {
                            Id = id;
                            State = State.Proposed;
                            Type = type;
                            Title = title;
                            Description = description;
                            StartDate = startDate;
                            EndDate = endDate;
                        }
                        else
                            throw new ArgumentException("The end date cannot be before the start date!");
                    else
                        throw new ArgumentException("The title must be at least one character long!");
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for title cannot be null!");
        }
    }
}