using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace AlonsoLibary
{
	public class FormHelper
	{
		public static Dictionary<string, string> ParseForm(Control container) {
			var result = new Dictionary<string, string>();

			foreach (Control ctrl in container.Controls)
			{
				ISmartControl c = ctrl as ISmartControl;
				if (c == null) continue;

				result.Add(ctrl.ID, c.GetValue());
			}

			return result;
		}
	}
}
