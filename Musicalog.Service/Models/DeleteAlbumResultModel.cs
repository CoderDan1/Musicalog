using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Musicalog.Service.Models
{
    [DataContract]
    public class DeleteAlbumResultModel
    {
        [DataMember]
        public string Message { get; set; }
    }
}