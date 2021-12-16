
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace FawzyShared.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Stream File { get; set; }
        [NotMapped]
        public byte[] Bytes { get; set; }
    }
}
