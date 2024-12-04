using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models.ViewModels
{
    public class DashboardVM
    {
        public int TotalUsers { get; set; }
        public int TotalChildren { get; set; }
        public int TotalParents { get; set; }
        public List<Feedback> FeedbackList { get; set; }
    }
}
