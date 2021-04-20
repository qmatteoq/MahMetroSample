using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahMetroSample.Entities
{
    public record Notification
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
