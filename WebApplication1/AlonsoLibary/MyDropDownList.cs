using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace AlonsoLibary
{
	public class MyDropDownList : DropDownList, ISmartControl
	{
		public string GetValue()
		{
			//return this.SelectedValue;
			return this.Text;
			//return this.SelectedItem.Value;
		}
	}
}
