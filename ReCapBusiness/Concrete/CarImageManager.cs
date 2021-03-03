using Microsoft.AspNetCore.Http;
using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectBusiness.ValidationRules.FluentValidation;
using ReCapProjectCore.Aspects.Autofac.Validation;
using ReCapProjectCore.Utilities.Business;

using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;

using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(Image image, CarImage carImage)
        {
            //Fotoğraf sayısını kontrol et
            var countResult = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (countResult != null)
            {
                return countResult;
            }
            //Resmi dosyaya ekle ardından yolunu veritabanına ekle
            var pathResult = CreatePath(image, carImage);
            if (pathResult.Success)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(pathResult.Messages);
            }
            return new ErrorResult(pathResult.Messages);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(p => p.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            //var olan resmi dosyadan sil
            var path = "wwwroot" + image.ImagePath;
            DeleteImage(path);   
            //veritabanından sil
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());

        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0,Id = 0, UploadDate = DateTime.Now, ImagePath = "/Images/defaultLogo.png" });

            return new SuccessDataResult<List<CarImage>>(images);
        }

        public IResult Update(Image image,CarImage carImage)
        {
            var findImages = _carImageDal.Get(p=> p.Id == carImage.Id);
            if (findImages == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            var path = "wwwroot" + findImages.ImagePath;
            DeleteImage(path);
            //Resmi dosyaya ekle ardından yolunu veritabanına ekle
            var pathResult = CreatePath(image, carImage);
            if (pathResult.Success)
            {
                _carImageDal.Update(carImage);
                return new SuccessResult(pathResult.Messages);
            }
            return new ErrorResult(pathResult.Messages);

        }



        private IResult CheckImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageNoLimit);
            }
            return new SuccessResult();
        }


        private IResult CreatePath(Image image, CarImage carImage)
        {
            //Yüklenecek Olan Dizin
            var path = "\\Images\\";
            var currentDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot");
            string createName = null;
            string extension = null;
            if (image.Files != null && image.Files.Length > 0)
            {
                createName = Guid.NewGuid().ToString("N")+carImage.CarId;
                extension = Path.GetExtension(image.Files.FileName);
                //wwwroot içerisinde images klasörü yoksa oluştur
                if (!Directory.Exists(currentDirectory + path))
                {
                    Directory.CreateDirectory(currentDirectory + path);
                }
                //Desteklenmeyen Dosyaları kontrol et
                if (extension != ".jpeg" && extension != ".png" && extension != ".jpg")
                {
                    return new ErrorResult(Messages.UnsupportedFile);
                }
                using (FileStream fileStream = File.Create(currentDirectory + path + createName + extension))
                {
                    image.Files.CopyTo(fileStream);
                    fileStream.Flush();
                    carImage.ImagePath = (path + createName + extension).Replace("\\", "/");
                    carImage.UploadDate = DateTime.Now;
                }
                return new SuccessResult(Messages.ImagesAdded);
            }
            return new ErrorResult(Messages.ImageNotFound);
        }

        private void DeleteImage(string path)
        {
            if (File.Exists(path.Replace("/", "\\")))
            {
                File.Delete(path.Replace("/", "\\"));
            }
        }
    }
}
