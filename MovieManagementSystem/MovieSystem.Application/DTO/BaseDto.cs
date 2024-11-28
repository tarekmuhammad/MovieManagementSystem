using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieSystem.Application.DTO
{
    public class BaseDto
    {
        public BaseDto()
        {
            HostName =  Helper.GetHostName.HostName;
            IPaddress = Helper.GetHostName.IPaddress;
        }
        [JsonIgnore]
        public DateTime? EntryDate { get; set; }
        [JsonIgnore]
        public string? EnteredBy { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public string? HostName { get; set; }
        [JsonIgnore]
        public string IPaddress { get; set; } 
    }
}
