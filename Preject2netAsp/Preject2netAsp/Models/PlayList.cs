using System;
using System.Collections.Generic;

namespace Preject2netAsp.Models
{
    public partial class PlayList
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string AudioStream { get; set; }
        public string TitleAudio { get; set; }
        public DateTime? DateToAdd { get; set; }
    }
}
