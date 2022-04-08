using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(50)]
        public string ContactUserName { get; set; }

        [StringLength(50)]
        public string ContactMail { get; set; }

        [StringLength(50)]
        public string ContactSUBJECT { get; set; }
        
        public string ContactMESSAGE { get; set; }
        public DateTime ContactMDate { get; set; }
    }
}
