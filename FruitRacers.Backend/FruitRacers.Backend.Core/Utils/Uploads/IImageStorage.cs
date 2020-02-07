﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public interface IImageStorage
    {
        Task<string> StoreImage(Stream imageStream, Action<IImageStoringOptions> options = null);

        Task DeleteImageAtPath(string path);
    }
}
