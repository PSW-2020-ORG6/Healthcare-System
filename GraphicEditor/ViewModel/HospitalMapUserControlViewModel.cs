using GraphicEditor.HelpClasses;
using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        private string _text = "AutoHook WORKS!!!!Changed colour :))";

        private List<string> _floorEntries = new List<string>();
        private string _floorEntry;

        public String RandomText
        {
            get => _text;
            set
            {
                OnPropertyChanged(RandomText);
            }
        }

        public List<string> FloorEntries
        {
            get => AddingFloors();
            set
            {
                OnPropertyChanged("FloorEntries");
            }
        }

        private List<string> AddingFloors()
        {
            _floorEntries.Add("Floor 1");
            _floorEntries.Add("Floor 2");
            _floorEntries.Add("Floor 3");
            _floorEntries.Add("Floor 4");
            _floorEntries.Add("Floor 5");
            return _floorEntries;
        }

        public string FloorEntry
        {
            get { return _floorEntry; }
            set
            {
                if (_floorEntry == value) return;
                _floorEntry = value;
                OnPropertyChanged("FloorEntry");
            }
        }
    }
}
