using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdd_dotnetcore_microservices.Models
{
    public class Employee : IEquatable<Employee>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        private long _id;

        public long Id
        {
            get { return 0; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return null; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return 0; }
            set { _age = value; }
        }

        public bool Equals(Employee other)
        {
            return other != null && this.Id == other.Id && this.Name.Equals(other.Name) && this.Age == other.Age;
        }
    }
}
