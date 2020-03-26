using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Path { get; set; }

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier LogoOwner { get; set; }
        public virtual Supplier BackgroundImageOwner { get; set; }
    }
}
