using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdd_dotnetcore_microservices.Models
{
    public class Employee : IEquatable<Employee>
    {
        private long _id;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool Equals(Employee other)
        {
            return other != null && this.Id == other.Id && this.Name.Equals(other.Name) && this.Age == other.Age;
        }
    }
}
