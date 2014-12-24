using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersList.Module.Resources;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace CustomersList.Module.BusinessObjects
{
    [NavigationItem("Customers")]
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            Addresses = new List<Address>();
        }

        [Key]
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [RuleRequiredField]
        public string FirstName { get; set; }
        [Required]
        [RuleRequiredField]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", LastName, FirstName, MiddleName); }
        }
        
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Aggregated]
        public virtual IList<Address> Addresses { get; set; }
    }
    
    [Table("Addresses")]
    public class Address
    {
        [Key]
        [Browsable(false)]
        public int Id { get; set; }
        [Required]
        public virtual City City { get; set; }
        [Required]
        [RuleRequiredField]
        public string Street { get; set; }
        [MaxLength(5)]
        [Required]
        [RuleRequiredField]
        public string House { get; set; }
        [MaxLength(5)]
        public string Building { get; set; }
        public AdddressType Type { get; set; }

        [NotMapped]
        public string FullAddress
        {
            get
            {
                string address = string.Format(Strings.AddressFormat, (City != null ? City.Name : string.Empty), Street, House);
                if (!string.IsNullOrWhiteSpace(Building))
                {
                    address += string.Format(Strings.BuildingFormat, Building);
                }

                return address;
            }
        }

        public virtual Customer Customer { get; set; }
    }

    [Table("Cities")]
    [NavigationItem("Lists")]
    public class City
    {
        [Key]
        [Browsable(false)]
        public int Id { get; set; }
        [Required]
        [RuleRequiredField]
        public string Name { get; set; }
    }

    public enum AdddressType
    {
        Home,
        Registration,
        Working
    }
}
