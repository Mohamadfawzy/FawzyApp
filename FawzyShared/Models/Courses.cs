using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawzyShared.Models
{
	public class Courses
	{
		[Key]
		public Guid ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
