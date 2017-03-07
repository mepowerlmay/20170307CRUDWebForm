using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace AlonsoLibary
{
	public class MyTextBox : TextBox, ISmartControl
	{
		public string GetValue()
		{
			return this.Text;
		}
	}
}
