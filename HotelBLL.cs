using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSTDC.BLL
{
    public class HotelBLL
    {
        public bool AddHotel(Hotel hotel)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    dbContext.Hotels.Add(hotel);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteHotel(int hotel_ID)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    var hotel = dbContext.Hotels.First(x => x.Hotel_ID == hotel_ID);
                    dbContext.Hotels.Remove(hotel);
                    dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateHotel(Hotel hotel)
        {
            try
            {
                using (MSTDCEntities dbContext = new MSTDCEntities())
                {
                    var hotel1 = dbContext.Hotels.Find(hotel.Hotel_ID);
                    hotel1.Hotel_ID = hotel.Hotel_ID;
                    hotel1.Hotel_Name = hotel.Hotel_Name;
                    hotel1.Hotel_Address =hotel.Hotel_Address;
                    hotel1.No_Of_Rooms=hotel.No_Of_Rooms;
                    hotel1.Place_ID =hotel.Place_ID;
                    hotel1.Category =hotel.Category;
                    hotel1.Hotel_Description =hotel.Hotel_Description;
                    hotel1.Image_Url=hotel.Image_Url;
                    dbContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Hotel ViewHotel(int hotel_ID)
        {
            Hotel hotel = new Hotel();
            try
            {
                using (MSTDCEntities DbContext = new MSTDCEntities())
                {
                    var hotel1 = DbContext.Hotels.Where(x => x.Hotel_ID == hotel_ID).First();
                    hotel = hotel1;
                    return hotel;
                }
            }
            catch (Exception e)
            {
                return hotel;
            }
        }
        public List<Hotel> ViewAllHotels()
        {
            List<Hotel> hotelList = new List<Hotel>();
            try
            {
                using (MSTDCEntities DbContext = new MSTDCEntities())
                {
                    var hotel1 = DbContext.Hotels.ToList();
                    hotelList = hotel1;
                    return hotelList;

                }
            }
            catch (Exception e)
            {
                return hotelList;
            }

        }
    }
}