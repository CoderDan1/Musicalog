using System;
using System.Runtime.Serialization;

namespace Musicalog.Service.Models
{
    [DataContract]
    public class EditModelDetailsRequest
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}