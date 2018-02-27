using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static User CurrentUser { get; set; }

        //    public User CurrentUser { get; set; }

        //public static Company Instance
        //{
        //    get
        //    {
        //        if (_company == null)
        //        {
        //            _company = new Company();
        //        }

        //        return _company;
        //    }
        //}

        #region Constructors
        public Company() { }
        #endregion Constructors
    }
}
