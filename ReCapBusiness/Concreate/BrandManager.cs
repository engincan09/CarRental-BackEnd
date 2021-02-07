using ReCapProjectBusiness.Abstract;
using ReCapProjectDataAccsess.Abstract;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concreate
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }

        public void Add(Brand brand)
        {
            _brand.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brand.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brand.GetAll();
        }

        public Brand GetBrand(int id)
        {
            return _brand.Get(p => p.Id == id);
        }

        public void Update(Brand brand)
        {
            _brand.Update(brand);
        }
    }
}
