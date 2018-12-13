﻿using Model.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ImageDAO : BaseDAO
    {
        public ImageDAO()
        {
            db = new TravelDatabase();
        }

        public static bool Insert(byte[] pictureOne, byte[] pictureTwo, byte[] pictureThree, string maTour)
        {
            db = new TravelDatabase();
            ImageTour image = new ImageTour();
            image.PictureOne = pictureOne;
            image.PictureTwo = pictureTwo;
            image.PictureThree = pictureThree;
            image.MaTour = maTour;

            db.ImageTours.Add(image);
            db.SaveChanges();

            return false;
        }

        public static ImageTour getById(string maTour)
        {
            return db.ImageTours.FirstOrDefault(x => x.MaTour == maTour);
        }

        //use this method in testing only
        public static bool InsertOne(byte[] picture, string maTour)
        {
            db = new TravelDatabase();
            ImageTour image = new ImageTour();
            image.PictureOne = picture;
            image.MaTour = maTour;

            db.ImageTours.Add(image);
            db.SaveChanges();

            return false;
        }

        public IPagedList<ImageTour> ListAll(int page = 1, int pageSize = 10)
        {
            var model = db.ImageTours.OrderBy(x => x.MaTour).ToPagedList(page, pageSize);
            return model;
        }
    }
}
