using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class Medicine
    {
        private String _copyRightName;
        private String _genericName;
        private String _manufacturer;
        private String _description;
        private bool _approved;

        public string CopyRightName { get => _copyRightName; set => _copyRightName = value; }
        public string GenericName { get => _genericName; set => _genericName = value; }
        public string Manufacturer { get => _manufacturer; set => _manufacturer = value; }
        public string Description { get => _description; set => _description = value; }
        public bool Approved { get => _approved; set => _approved = value; }
    }
}
