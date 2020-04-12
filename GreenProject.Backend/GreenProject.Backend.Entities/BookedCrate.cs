﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Entities
{
    public class BookedCrate
    {
        public BookedCrate()
        {
            Compositions = new HashSet<BookedCrateComposition>();
        }

        public int BookedCrateId { get; set; }
        public int UserId { get; set; }
        public int CrateId { get; set; }

        public virtual User User { get; set; }
        public virtual Crate Crate { get; set; }
        public virtual ICollection<BookedCrateComposition> Compositions { get; set; }
    }
}