using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ReportEntry
    {
        public ReportEntry(DateTime date, string message, uint cost, Member author, ITask task)
        {
            if (message != null)
                if (author != null)
                    if (task != null)
                        if (task.StartDate <= date && date <= task.EndDate)
                            if (message.Length >= 10)
                            {
                                Date = date;
                                Message = message;
                                Cost = cost;
                                Author = author;
                                Task = task;
                            }
                            else
                                throw new ArgumentException("The report entry message must be at least 10 characters long!");
                        else
                            throw new ArgumentException("The report entry cannot be created because the report date is outside the task time frame!");
                    else
                        throw new ArgumentNullException("The provided value for task cannot be null");
                else
                    throw new ArgumentNullException("The provided value for author cannot be null");
            else
                throw new ArgumentNullException("The provided value for message cannot be null");
        }

        public ReportEntry(string message, uint cost, Member author, ITask task)
            : this(DateTime.Now, message, cost, author, task)
        {
        }

        public DateTime Date { get; private set; }

        public string Message { get; private set; }

        public uint Cost { get; private set; }

        public Member Author { get; private set; }

        public ITask Task { get; private set; }
    }
}
