using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawzyShared.Models
{
	public class Students_Courses
	{
		[Key]
		public Guid ID { get; set; }

		[ForeignKey("Students")]
		public Guid Student_Id { get; set; }
		[ForeignKey("Courses")]
		public Guid Course_Id { get; set; }

		public virtual Students Students { get; set; }
		public virtual Courses Courses { get; set; }

		void d()
        {

		}
	}
}
