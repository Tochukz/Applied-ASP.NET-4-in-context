using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLApp.Attributes
{
	public class ModelPropAttribute : Attribute
	{
		private string _attrName;

		public string AttrName {
			get => _attrName;
		}

		public ModelPropAttribute(string attrName)
		{
			_attrName = attrName;
		}
	}
}
