using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MSTDC.BLL
{
    public class CityBLL
    {

        public bool AddCity(City city)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    dbContext.Cities.Add(city);
                    dbContext.SaveChanges();
                }
                    
                    return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public bool DeleteCity(int city_id)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    var s= dbContext.Cities.First(x => x.City_ID == city_id);
                    dbContext.Cities.Remove(s);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateCity(City city)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    var city1 = dbContext.Cities.Find(city.City_ID);
                    city1.City_ID = city.City_ID;
                    city1.City_Name = city.City_Name;
                    city1.District = city.District;
                    dbContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public City ViewCity(int City_ID)
        {
            City city = new City();
            try
            {
                using (MSTDCEntities DbContext = new MSTDCEntities())
                {
                    var city1 = DbContext.Cities.Where(x => x.City_ID == City_ID).First();
                    city = city1;
                    return city;
                }
            }
            catch (Exception e)
            {
                return city;
            }
        }
        public List<City> ViewAllCities()
        {
            List<City> cityList = new List<City>();
            try
            {
                using (MSTDCEntities DbContext = new MSTDCEntities())
                {
                    var cities = DbContext.Cities.ToList();
                    cityList = cities;
                    return cityList;

                }
            }
            catch (Exception e)
            {
                return cityList;
            }

        }
        
    }
}