using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.Comment
{
	public class CommentServiceModel
	{
		public string Review { get; set; } = string.Empty;
		public string UserId { get; set; } = string.Empty;
		public int? Rating { get; set; }
	}
}
