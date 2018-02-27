using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TypeOfUser
    {
        #region Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsManager { get; set; }
        public bool IsEmployee { get; set; }
        #endregion Fields

        #region Constructor
        public TypeOfUser() { }

        #endregion Constructor
    }
}
