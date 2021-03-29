using System;
using System.Runtime.Serialization;

namespace Musicalog.Service.Models
{
    [DataContract]
    public class ActionResultModel
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Guid EntityId { get; set; }
    }
}
