using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AddressRegister.Domain.Entities
{
    public class Address : Entity
    {
        public string ZipCode { get; private set; }
        public int Number { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Complement { get; private set; }
        public string State { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }

        public Address()
        {
        }

        public Address(string zipCode, int number, string city, string district, string complement, string state, int userId)
        {
            ZipCode = zipCode;
            Number = number;
            City = city;
            District = district;
            Complement = complement;
            State = state;
            UserId = userId;
        }

        public void UpdateNumber(int number)
        {
            Number = number;
        }
        public void UpdateComplement(string complement)
        {
            Complement = complement;
        }

        public void SetUser(User user)
        {
            User = user;
        }

    }
}
