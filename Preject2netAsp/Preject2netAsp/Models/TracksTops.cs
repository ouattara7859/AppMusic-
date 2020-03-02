using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preject2netAsp.Models
{
    public class TracksTops
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
   
        public string Artist_id { get; set; }
        public string Artist_name { get; set; }
        public string Artist_idstr { get; set; }
        public string Album_name { get; set; }
        public string Albums_id { get; set; }
        public string License_ccurl { get; set; }
        public string Position { get; set; }
        public string Releasedate { get; set; }
        public string Album_Image { get; set; }
        public string Audio { get; set; }
        public string Audiodownload { get; set; }
    }
}
