﻿using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public class ImageResource : IImageResource
    {
        private readonly IImageStorage storage;
        private readonly Action<IImageStoringOptions> storingOptions;
        private readonly Func<Image> imageSupplier;
        private readonly Action<Image> imageSetter;
        private readonly IDataSession data;

        public ImageResource(
            IImageStorage storage,
            Action<IImageStoringOptions> storingOptions,
            Func<Image> imageSupplier,
            Action<Image> imageSetter,
            IDataSession data)
        {
            this.imageSupplier = imageSupplier;
            this.imageSetter = imageSetter;
            this.storage = storage;
            this.storingOptions = storingOptions;
            this.data = data;
        }

        public async Task Delete()
        {
            Image currentImage = this.imageSupplier();
            if (currentImage is null)
            {
                throw new NotFoundException(); // TODO: use proper exception
            }
            await storage.DeleteImageAtPath(currentImage.Path);
            await this.data.Images.Delete(currentImage);
            await this.data.SaveChanges();
        }

        public async Task Store(Stream imageStream)
        {
            Image currentImage = this.imageSupplier();
            if (currentImage != null)
            {
                await storage.DeleteImageAtPath(currentImage.Path);
            }
            string newPath = await storage.StoreImage(imageStream, this.storingOptions);
            if (currentImage == null)
            {
                currentImage = new Image();
                this.imageSetter(currentImage);
            }
            currentImage.Path = newPath;
            await this.data.SaveChanges();
        }
    }
}