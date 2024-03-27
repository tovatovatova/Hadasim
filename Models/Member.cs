using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COVID_19_Hadasim_.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }

        public int MemberId { get; set; }
        public string MemberAddress { get; set; }
        public string MemberCity { get; set; }
        public int HouseNumber { get; set; }
        [DataType(DataType.Date)] //For validation and view
        public DateTime BirthDate { get; set; }
        public string? MemberPhone { get; set; }
        public string? MemberMobilePhone { get; set; }
        public string? MemberImage { get; set; }
        [DataType(DataType.Date)] //For validation and view
        public DateTime? PositiveRes { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RecoveryDate { get; set; }

    }
    
}
