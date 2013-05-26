using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Role
    {
        public static bool operator ==(Role x, string name)
        {
            return string.Compare(x.Name, name, true) == 0;
        }

        public static bool operator ==(string name, Role y)
        {
            return y == name;
        }

        public static bool operator ==(Role x, Role y)
        {
            return x == y.Name;
        }

        public static bool operator ==(Role x, object y)
        {
            if (y != null && y is Role)
                return x == (Role)y;
            else
                return false;
        }

        public static bool operator ==(object x, Role y)
        {
            return y == x;
        }

        public static bool operator !=(Role x, string name)
        {
            return !(x == name);
        }

        public static bool operator !=(string name, Role y)
        {
            return !(y == name);
        }

        public static bool operator !=(Role x, Role y)
        {
            return !(x == y);
        }

        public static bool operator !=(Role x, object y)
        {
            return !(x as object == y);
        }

        public static bool operator !=(object x, Role y)
        {
            return !(x == y);
        }

        public static bool Add(string name, string description, ICollection<string> featureNames)
        {
            if (name != null)
                if (description != null)
                    return roles.Add(new Role(name, description, featureNames));
                else
                    throw new ArgumentNullException("The provided description cannot be null!");
            else
                throw new ArgumentNullException("The provided name cannot be null!");
        }

        public static bool Add(string name, ICollection<string> featureNames)
        {
            return Add(name, string.Empty, featureNames);
        }

        public static void Clear()
        {
            roles.Clear();
        }

        public static bool Exists(string name)
        {
            Role role;
            return TryWithName(name, out role);
        }

        public static bool Remove(string name)
        {
            if (name != null)
            {
                IEnumerable<Role> selectedRoles = roles.Where((role) => role == name);
                if (selectedRoles.Count() == 1)
                {
                    roles.Remove(selectedRoles.First());
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

        public static bool TryWithName(string name, out Role role)
        {
            if (name != null)
            {
                IEnumerable<Role> selectedRoles = roles.Where((r) => r == name);
                if (selectedRoles.Count() == 1)
                {
                    role = selectedRoles.First();
                    return true;
                }
                else
                {
                    role = new Role(name);
                    return false;
                }
            }
            else
            {
                role = new Role("");
                return false;
            }
        }

        public static Role WithName(string name)
        {
            if (name != null)
            {
                IEnumerable<Role> selectedRoles = roles.Where((role) => role == name);
                if (selectedRoles.Count() == 1)
                    return selectedRoles.First();
                else
                    throw new IndexOutOfRangeException("There is no role with the name " + name + "!");
            }
            else
                throw new ArgumentNullException("The provided name cannot be null!");
        }

        public static IEnumerable<Role> WithNames(IEnumerable<string> names)
        {
            if (names != null)
                return roles.Where((role) => names.Contains(role.Name, new Collections.EqualityComparer<string>((x, y) => string.Compare(x, y, true) == 0)));
            else
                throw new ArgumentNullException("The provided name collection cannot be null!");
        }

        public static IEnumerable<Role> WithNames(params string[] names)
        {
            return WithNames(names as IEnumerable<string>);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Role)
                return this == (Role)obj;
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
            set
            {
                if (value != null)
                    if (value.Length > 3)
                        name = value;
                    else
                        throw new ArgumentException("The provided value for name is to short to be a role name!");
                else
                    throw new ArgumentNullException("The provided value for name cannot be null!");
            }
        }

        public string Desciption
        {
            get
            {
                return description;
            }
            private set
            {
                if (description != null)
                    description = value;
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            }
        }

        public ICollection<string> FeatureNames
        {
            get
            {
                return featureNames;
            }
            private set
            {
                if (featureNames != null)
                    featureNames = value;
                else
                    throw new ArgumentNullException("The provided value for featureNames cannot be null!");
            }
        }

        public Role(string name)
        {
            if (name != null)
                if (name.Length > 4)
                {
                    this.name = name;
                    this.description = string.Empty;
                    this.featureNames = new List<string>();
                }
                else
                    throw new ArgumentException("The provided name must have more than 4 characters");
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        public Role(string name, string description, ICollection<string> featureNames)
        {
            if (name != null)
                if (description != null)
                    if (name.Length > 4)
                    {
                        this.name = name;
                        this.description = description;
                        this.featureNames = featureNames;
                    }
                    else
                        throw new ArgumentException("The provided name must have more than 4 characters");
                else
                    throw new ArgumentNullException("The provided value for descritpion cannot be null!");
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        private string name;
        private string description;
        private static ISet<Role> roles = new SortedSet<Role>(new Collections.Comparer<Role>((x, y) => string.Compare(x.Name, y.Name)));
        private ICollection<string> featureNames;
    }

}
