using CRUDCatalogoPersonas.SharedKernel.Interfaces;
using CRUDCatalogoPersonas.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using System.Xml.Linq;

namespace CRUDCatalogoPersonas.Core.PeopleAggregate
{
    public class People : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

        public People(string name, string lastName, string address, string email, string phone, string gender)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Address = Guard.Against.NullOrEmpty(address, nameof(address));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Gender = Guard.Against.NullOrEmpty(gender, nameof(gender));
        }

        public void UpdatePeople(string name, string lastName, string address, string email, string phone, string gender)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Address = Guard.Against.NullOrEmpty(address, nameof(address));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Gender = Guard.Against.NullOrEmpty(gender, nameof(gender));
        }
    }
}
