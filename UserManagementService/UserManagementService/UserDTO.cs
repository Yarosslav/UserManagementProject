using System;
using System.Runtime.Serialization;

namespace UserManagementService
{
    [DataContract]
    public class UserDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string FullName { get; set; }
        [DataMember] public string DRFO { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string Phone { get; set; }
        [DataMember] public DateTime DateCreated { get; set; }
        [DataMember] public DateTime DateModified { get; set; }
    }
}
