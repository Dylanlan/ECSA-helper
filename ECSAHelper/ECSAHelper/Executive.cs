using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSAHelper
{
    public class Executive
    {
        public Executive()
        {
            this.position = "New Position";
        }

        public Executive(string position)
        {
            this.position = position;
        }

        [DisplayName("Position")]
        [Category("Executive Info")]
        public string position { get; set; }

        [DisplayName("Full Name")]
        [Category("Executive Info")]
        public string fullName { get; set; }

        [DisplayName("Email")]
        [Category("Executive Info")]
        public string email { get; set; }

        [DisplayName("Biography")]
        [Category("Executive Info")]
        public string bio { get; set; }

        [Browsable(false)]
        public string imageUrl { get; set; }

        public override string ToString()
        {
            return this.position.ToString();
        }
    }
}
