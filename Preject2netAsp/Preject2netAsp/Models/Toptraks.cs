using System;
using System.Collections.Generic;

namespace Preject2netAsp.Models
{
    public partial class Toptraks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
        public int? ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistIdstr { get; set; }
        public string AlbumName { get; set; }
        public int? AlbumId { get; set; }
        public string LicenseCcurl { get; set; }
        public int? Position { get; set; }
        public DateTime? Releasedate { get; set; }
        public string Audio { get; set; }
        public string Audiodownload { get; set; }
    }
}
