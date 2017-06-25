using System.Runtime.Serialization;

namespace Server_WCF_IIS
{
    [DataContract]
    public struct MSG
    {
        [DataMember]
        public string Op_name { get; set; }
        [DataMember]
        public bool Op_statut { get; set; }
        [DataMember]
        public string Op_infos { get; set; }
        [DataMember]
        public string TokenApp { get; set; }
        [DataMember]
        public string TokenUser { get; set; }
        [DataMember]
        public object[] data;
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
