using System.ComponentModel.DataAnnotations;

namespace Adventure.EFCodeFirst.Models
{
    public class CustomerDTO
    {
        [Key]
        public int CustomerID { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        [StringLength(128)]
        public string CompanyName { get; set; }

        //[StringLength(256)]
        //public string SalesPerson { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        //[StringLength(25)]
        //public string Phone { get; set; }
    }
}
