using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MSTDC.BLL
{
    public class PlacesBLL
    {
        public bool AddPlace(Place place)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    dbContext.Places.Add(place);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeletePlace(int Place_ID)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    var place = dbContext.Places.First(x => x.Place_ID == Place_ID);
                    dbContext.Places.Remove(place);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdatePlace(Place place)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    var place1 = dbContext.Places.Find(place.Place_ID);
                    place1.Place_ID = place.Place_ID;
                    place1.Place_Name = place.Place_Name;
                    place1.Description = place.Description;
                    place1.City_ID = place.City_ID;
                    dbContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Place ViewPlace(int Place_ID)
        {
            Place place = new Place();
            try
            {
                using (MSTDCEntities DbContext = new MSTDCEntities())
                {
                    var place1 = DbContext.Places.Where(x => x.Place_ID == Place_ID).First();
                    place = place1;
                    return place;
                }
            }
            catch (Exception e)
            {
                return place;
            }
        }
        public List<Place> ViewAllPlaces()
        {
            List<Place> placeList = new List<Place>();
            try
            {
                using (MSTDCEntities DbContext = new MSTDCEntities())
                {
                    var places = DbContext.Places.ToList();
                    placeList = places;
                    return placeList;

                }
            }
            catch (Exception e)
            {
                return placeList;
            }

        }
    }
}