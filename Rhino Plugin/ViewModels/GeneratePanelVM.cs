using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino_Plugin.ViewModels
{
    public class GeneratePanelVM : Notifier
    {
		private string _lengthx;

		public string LengthX
		{
			get { return _lengthx; }
			set {
				if (value == _lengthx) return;
				_lengthx = value.ToString();
				OnPropertyChanged(nameof(LengthX));
			}
		}

	}
}
