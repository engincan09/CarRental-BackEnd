using Microsoft.AspNetCore.Http;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(Image image, CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> Get(int imageId);
    }
}
