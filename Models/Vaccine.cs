using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COVID_19_Hadasim_.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        [ForeignKey("MemberId") ]
        public int MemberID { get; set; }
        public int VaccineNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime VaccineDate { get; set; }   
        public string VaccineManufacturer { get; set; }
    }
}
