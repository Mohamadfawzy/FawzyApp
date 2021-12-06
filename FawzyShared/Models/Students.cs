using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawzyShared.Models
{
	public class Students
	{
		[Key]
		public Guid ID { get; set; }
		public string Name { get; set; }
		public int Phones { get; set; }
		public int SSD { get; set; }
	}
}
