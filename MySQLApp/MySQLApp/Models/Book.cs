using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySQLApp.Attributes;

namespace MySQLApp.Models
{
	public class Book
	{
		[ModelProp("PrimaryKey")]
		public int  bookId { set; get; }
		public string title { set; get; }
		public string author { set; get; }
		public int subcategoryId { set; get; }
		public string edition { set; get; }
		public float price { set; get; }

		public DateTime createdAt { set; get; }
		public DateTime updatedAt { set; get; }
	}
}
