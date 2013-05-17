using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public struct TaskType
    {
        public static bool operator ==(TaskType x, string name)
        {
            return string.Compare(x.Name, name, true) == 0;
        }

        public static bool operator ==(string name, TaskType y)
        {
            return y == name;
        }

        public static bool operator ==(TaskType x, TaskType y)
        {
            return x == y.Name;
        }

        public static bool operator ==(TaskType x, object y)
        {
            if (y != null && y is TaskType)
                return x == (TaskType)y;
            else
                return false;
        }

        public static bool operator ==(object x, TaskType y)
        {
            return y == x;
        }

        public static bool operator !=(TaskType x, string name)
        {
            return !(x == name);
        }

        public static bool operator !=(string name, TaskType y)
        {
            return !(y == name);
        }

        public static bool operator !=(TaskType x, TaskType y)
        {
            return !(x == y);
        }

        public static bool operator !=(TaskType x, object y)
        {
            return !(x == y);
        }

        public static bool operator !=(object x, TaskType y)
        {
            return !(x == y);
        }

        public static bool Add(string name, string description)
        {
            if (name != null)
                if (description != null)
                    return taskTypes.Add(new TaskType(name, description));
                else
                    throw new ArgumentNullException("The provided description cannot be null!");
            else
                throw new ArgumentNullException("The provided name cannot be null!");
        }

        public static bool Add(string name)
        {
            return Add(name, string.Empty);
        }

        public static void Clear()
        {
            taskTypes.Clear();
        }

        public static bool Exists(string name)
        {
            TaskType type;
            return TryWithName(name, out type);
        }

        public static bool Remove(string name)
        {
            if (name != null)
            {
                IEnumerable<TaskType> selectedTaskTypes = taskTypes.Where((taskType) => taskType == name);
                if (selectedTaskTypes.Count() == 1)
                {
                    taskTypes.Remove(selectedTaskTypes.First());
                    return true;
                }
                else
                    return false;
            }
            else
                throw new ArgumentNullException("The provided name cannot be null!");
        }

        public static void Remove(IEnumerable<string> names)
        {
            if (names != null)
                foreach (string name in names)
                    Remove(names);
            else
                throw new ArgumentNullException("The provided names collection cannot be null!");
        }

        public static void Remove(params string[] names)
        {
            Remove(names as IEnumerable<string>);
        }

        public static bool TryWithName(string name, out TaskType type)
        {
            if (name != null)
            {
                IEnumerable<TaskType> selectedTaskTypes = taskTypes.Where((taskType) => taskType == name);
                if (selectedTaskTypes.Count() == 1)
                {
                    type = selectedTaskTypes.First();
                    return true;
                }
                else
                {
                    type = new TaskType();
                    return false;
                }
            }
            else
            {
                type = new TaskType();
                return false;
            }
        }

        public static TaskType WithName(string name)
        {
            if (name != null)
            {
                IEnumerable<TaskType> selectedTaskTypes = taskTypes.Where((taskType) => taskType == name);
                if (selectedTaskTypes.Count() == 1)
                    return selectedTaskTypes.First();
                else
                    throw new IndexOutOfRangeException("There is no task type with the name " + name + "!");
            }
            else
                throw new ArgumentNullException("The provided name cannot be null!");
        }

        public static IEnumerable<TaskType> WithNames(IEnumerable<string> names)
        {
            if (names != null)
                return taskTypes.Where((taskType) => names.Contains(taskType.Name, new Collections.EqualityComparer<string>((x, y) => string.Compare(x, y, true) == 0)));
            else
                throw new ArgumentNullException("The provided name collection cannot be null!");
        }

        public static IEnumerable<TaskType> WithNames(params string[] names)
        {
            return WithNames(names as IEnumerable<string>);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is TaskType)
                return this == (TaskType)obj;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Desciption
        {
            get
            {
                return desciption;
            }
        }

        private TaskType(string name, string description)
        {
            if (name != null)
                if (description != null)
                    if (name.Length > 4)
                    {
                        this.name = name;
                        this.desciption = description;
                    }
                    else
                        throw new ArgumentException("The provided name must have more than 4 characters");
                else
                    throw new ArgumentNullException("The provided value for descritpion cannot be null!");
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        private string name;
        private string desciption;
        private static ISet<TaskType> taskTypes = new SortedSet<TaskType>(new Collections.Comparer<TaskType>((x, y) => string.Compare(x.Name, y.Name)));
    }
}
