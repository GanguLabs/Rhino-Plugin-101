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

        private string _lengthy;

        public string LengthY
        {
            get { return _lengthy; }
            set
            {
                if (value == _lengthy) return;
                _lengthy = value.ToString();
                OnPropertyChanged(nameof(LengthY));
            }
        }

		private string _xCoord;

		public string XCoord
		{
			get { return _xCoord; }
            set
            {
                if (value == _xCoord) return;
                _xCoord = value.ToString();
                OnPropertyChanged(nameof(XCoord));
            }
        }

		private string _yCoord;

		public string YCoord
		{
			get { return _yCoord; }
            set
            {
                if (value == _yCoord) return;
                _yCoord = value.ToString();
                OnPropertyChanged(nameof(YCoord));
            }
        }

		private string _zCoord;

		public string ZCoord
		{
			get { return _zCoord; }
            set
            {
                if (value == _zCoord) return;
                _zCoord = value.ToString();
                OnPropertyChanged(nameof(ZCoord));
            }
        }

	}
}
