using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }

        public string WorkName { get; set; }

        public DateTime WorkStartDate { get; set; }

        public DateTime WorkEndDate { get; set; }

        public bool Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
