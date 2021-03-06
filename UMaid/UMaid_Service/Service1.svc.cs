using System;
using System.Collections.Generic;
using System.Linq;
using System.Device.Location;
using DAL;
using Model;

namespace UMaid_Service
{
    public class Service1 : IService1
    {   
        public Dto_User GetUser(Dto_User user)
        {
            Dto_User p = new Dto_User();
            try
            {
                using (UMaidEntities db = new  UMaidEntities())
                {
                
                    var singleRecord = db.Users.Where(i => i.EmailID == user.Email
                                            && i.passWord == user.Password).SingleOrDefault();
                    if (singleRecord != null)
                    {
                        if (singleRecord.userID == 0)
                        {
                            p.ErrorMessage = "not found";
                            p.Error = true;
                            return p;
                        }
                        else
                        {
                            p.UserID = singleRecord.userID;
                            p.UserTypeID = singleRecord?.UserType ?? 0;
                            p.FName = singleRecord.FName;
                            p.LName = singleRecord.LName;
                            p.Email = singleRecord.EmailID;
                            p.Password = singleRecord.passWord;
                            p.PhoneNumber = singleRecord.PhoneNumber;
                            p.StreetName = singleRecord.StreetName;
                            p.City = singleRecord.City;
                            p.PostalCode = singleRecord.PostalCode;
                            p.State = singleRecord.State;
                            p.StartDate = singleRecord.StartDate;
                            p.Rating = singleRecord.Rating;
                            p.NumOfRatings = singleRecord.numOfRating;

                            p.Error = false;
                        }
                    }
                    else
                    {
                        p.ErrorMessage = "not found";
                        p.Error = true;
                    }

                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;

            }

            return p;
        }
        #region AccessUserTypes

        public Dto_UserType GetUserType(Dto_User user)
        {
            Dto_UserType p = new Dto_UserType();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var singleRecord = db.UserTypes.
                    Where(c => c.UserTypeID == user.UserTypeID).FirstOrDefault();

                    if (singleRecord != null)
                    {
                        if (singleRecord.UserTypeID == 0)
                        {
                            p.ErrorMessage = "not found";
                            p.Error = true;
                            return p;
                        }
                        else
                        {
                            p.UserTypeID = singleRecord.UserTypeID;
                            p.UserTypeDescription = singleRecord.UserTypeDescription;
                            p.Error = false;
                        }
                    }
                    else
                    {
                        p.ErrorMessage = "not found";
                        p.Error = true;
                    }
                
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;

            }
            return p;
        }
        #endregion AccessUserTypes

        #region accessTableUsers
        public Dto_User GetUserByUserID(Dto_User user)
        {
            Dto_User p = new Dto_User();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var singleRecord = db.Users.Where(
                        c => c.userID == user.UserID).FirstOrDefault();

                    if (singleRecord != null)
                    {
                        if (singleRecord.userID == 0)
                        {
                            p.ErrorMessage = "not found";
                            p.Error = true;
                            return p;
                        }
                        else
                        {

                            p.UserID = singleRecord.userID;
                            p.UserTypeID = (int)singleRecord.UserType;
                            p.Email = singleRecord.EmailID;
                            p.FName = singleRecord.FName;
                            p.LName = singleRecord.LName;
                            p.Password = singleRecord.passWord;
                            p.PhoneNumber = singleRecord.PhoneNumber;
                            p.StreetName = singleRecord.StreetName;
                            p.City = singleRecord.City;
                            p.PostalCode = singleRecord.PostalCode;
                            p.State = singleRecord.State;
                            p.StartDate = singleRecord.StartDate;
                            p.Rating = singleRecord.Rating;
                            p.NumOfRatings = singleRecord.numOfRating;
                            p.Error = false;
                        }
                    }
                    else
                    {
                        p.ErrorMessage = "not found";
                        p.Error = true;
                    }
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;

            }
             return p;
        }

        public Dto_User InsertUser(Dto_User user)
        {
            Dto_User p = new Dto_User();
            try {
                using (UMaidEntities db = new UMaidEntities())
                {

                    var singleRecord = new DAL.User();

                    singleRecord.UserType = (int)user.UserTypeID;
                    singleRecord.EmailID = user.Email;
                    singleRecord.FName = user.FName;
                    singleRecord.LName = user.LName;
                    singleRecord.passWord = user.Password;
                    singleRecord.PhoneNumber = user.PhoneNumber;
                    singleRecord.StreetName = user.StreetName;
                    singleRecord.City = user.City;
                    singleRecord.PostalCode = user.PostalCode;
                    singleRecord.State = user.State;
                    singleRecord.Rating = user.Rating;
                    singleRecord.numOfRating = user.NumOfRatings;
                    try
                    {
                        singleRecord.StartDate = user.StartDate;

                    }
                    catch (Exception ex)
                    {
                        p.Error = true;
                        p.ErrorMessage = ex.Message;
                        p.UserID = -1;
                        return p;
                    }

                    var newRecord = db.Users.Add(singleRecord);
                    db.SaveChanges();

                    if (newRecord != null)
                    {
                        if (newRecord.userID == 0)
                        {
                            p.Error = true;
                            p.ErrorMessage = "Insert into table Users was unsuccessful !!!";
                            return p;
                        }
                        else
                        {
                            p.UserID = newRecord.userID;
                            p.UserTypeID = (int)newRecord.UserType;
                            p.Email = newRecord.EmailID;
                            p.FName = newRecord.FName;
                            p.LName = newRecord.LName;
                            p.Password = newRecord.passWord;
                            p.PhoneNumber = newRecord.PhoneNumber;
                            p.StreetName = newRecord.StreetName;
                            p.City = newRecord.City;
                            p.PostalCode = newRecord.PostalCode;
                            p.State = newRecord.State;
                            p.StartDate = newRecord.StartDate;
                            p.Rating = newRecord.Rating;
                            p.NumOfRatings = newRecord.numOfRating;
                            p.Error = false;
                        }
                    }
                    else
                    {
                        p.ErrorMessage = "Invalid data provided  ";
                        p.Error = true;
                    }
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = "Invalid data provided  " + ex.Message;
                
            }
            return p;
        }

        public Dto_Bool UpdateUser(Dto_User user)
        {
            Dto_Bool success = new Dto_Bool();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    //fetching the existing record whose UserID == user.UserID from 
                    //the database
                    var userRecordFromDB = db.Users.Where(
                        c => c.userID == user.UserID).FirstOrDefault();

                    //changing the values
                    if (userRecordFromDB != null)
                    {
                        if (userRecordFromDB.userID == 0)
                        {
                            success.success = false;
                            success.ErrorMessage = "User does not exist. ";
                            return success;
                        }
                        else
                        {
                            userRecordFromDB.FName = user.FName;
                            userRecordFromDB.LName = user.LName;
                            userRecordFromDB.UserType = (int)user.UserTypeID;
                            userRecordFromDB.EmailID = user.Email;
                            userRecordFromDB.FName = user.FName;
                            userRecordFromDB.LName = user.LName;
                            userRecordFromDB.passWord = user.Password;
                            userRecordFromDB.PhoneNumber = user.PhoneNumber;
                            userRecordFromDB.StreetName = user.StreetName;
                            userRecordFromDB.City = user.City;
                            userRecordFromDB.PostalCode = user.PostalCode;
                            userRecordFromDB.State = user.State;
                            userRecordFromDB.Rating = user.Rating;
                            userRecordFromDB.numOfRating = user.NumOfRatings;
                            try
                            {
                                userRecordFromDB.StartDate = user.StartDate;

                            }
                            catch (Exception ex)
                            {

                                success.success = false;
                                success.ErrorMessage = ex.Message;
                                return success;
                            }
                            //updating the values in database
                            db.SaveChanges();

                            success.success = true;
                        }
                    }
                    else
                    {
                        success.success = false;
                        success.ErrorMessage = "Not Found .";
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                success.success = false;
                success.ErrorMessage = ex.Message;
            }
            return success;
        }
        public Dto_Bool DeleteUser(Dto_User user)
        {
            
            Dto_Bool success = new Dto_Bool();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var userRecordFromDB = db.Users.Where(
                        c => c.userID == user.UserID).FirstOrDefault();
                    if (userRecordFromDB != null)
                    {
                        if (userRecordFromDB.userID == 0)
                        {
                            success.success = false;
                            success.ErrorMessage = "User does not exist. ";
                            return success;
                        }
                        else
                        {
                            DAL.User u = db.Users.Remove(userRecordFromDB);

                            db.SaveChanges();
                            success.success = true;
                        }
                    }
                    else
                    {
                        success.success = false;
                        success.ErrorMessage = "Not Found .";
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                success.success = false;
                success.ErrorMessage = ex.Message;
            }
            return success;
        }

        
        public List<Dto_User> GetAllUsers()
        {
            List<Dto_User> users = new List<Dto_User>();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var list = db.Users;
                    foreach (var u in list)
                    {
                        var p = new Dto_User();
                        p.UserID = u.userID;
                        p.UserTypeID = (int)u.UserType;
                        p.Email = u.EmailID;
                        p.FName = u.FName;
                        p.LName = u.LName;
                        p.Password = u.passWord;
                        p.PhoneNumber = u.PhoneNumber;
                        p.StreetName = u.StreetName;
                        p.City = u.City;
                        p.PostalCode = u.PostalCode;
                        p.State = u.State;
                        p.StartDate = u.StartDate;
                        p.Rating = u.Rating;
                        p.NumOfRatings = u.numOfRating;

                        users.Add(p);
                    }
                }
            }
            catch(Exception ex)
            {
                return users;//an empty list of Users

            }

            return users;//populated list of Users
        }

        #endregion accessTableUsers

        #region accessTableProfile

        
        public Dto_Profile GetProfile(Dto_User user)
        {
            Dto_Profile p = new Dto_Profile();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var singleRecord = db.Profiles.Where(c => c.userID == user.UserID).
                    FirstOrDefault();

                    if (singleRecord != null)
                    {
                        if (singleRecord.profileID == 0)
                        {
                            p.ErrorMessage = "not found";
                            p.Error = true;
                            return p;
                        }
                        else
                        {
                            p.ProfileID = singleRecord.profileID;
                            p.UserID = singleRecord.userID;
                            p.PictureID = (int)singleRecord.pictureID;
                            p.AccountNumber = (int)singleRecord.AccountNumber;
                            p.AvgRating = (double)singleRecord.AvgRating;
                            p.Bio = singleRecord.Bio;


                            var pictureRecord = db.Pictures.Where(
                                c => c.pictureID == singleRecord.pictureID
                            ).SingleOrDefault();
                            if (pictureRecord != null)
                            {
                                p.PicturePath = pictureRecord.picturePath;
                            }
                            else
                            {
                                p.PicturePath = "";
                            }
                            p.Error = false;
                        }
                    }
                    else
                    {
                        p.ErrorMessage = "not found";
                        p.Error = true;
                        return p;
                    }
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;
            }
    
            return p;
        }

        public Dto_Profile InsertProfile(Dto_Profile profile)
        {
            Dto_Profile p = new Dto_Profile();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                   var singleRecord = new DAL.Profile();

                    singleRecord.userID = profile.UserID;
                    singleRecord.pictureID = (int)profile.PictureID;
                    singleRecord.AccountNumber = profile.AccountNumber;
                    singleRecord.AvgRating = profile.AvgRating;
                    singleRecord.Bio = profile.Bio;

                    var newRecord = db.Profiles.Add(singleRecord);
                    db.SaveChanges();

                    if (newRecord != null)
                    {
                        if (newRecord.profileID == 0)
                        {
                            p.ErrorMessage = "Insert into table Profiles was unsuccessful. ";
                            p.Error = true;
                            return p;
                        }
                        else
                        {
                            p.ProfileID = newRecord.profileID;
                            p.UserID = newRecord.userID;
                            p.PictureID = (int)newRecord.pictureID;
                            p.AccountNumber = (int)newRecord.AccountNumber;
                            p.AvgRating = (double)newRecord.AvgRating;
                            p.Bio = newRecord.Bio;

                            p.Error = false;
                        }

                    }
                    else
                    {
                        p.Error = true;
                        p.ErrorMessage = "Insert into table Profiles was unsuccessful !!!";

                    }
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;
            }
              
            return p;
        }

        public Dto_Bool UpdateProfile(Dto_Profile profile)
        {
            Dto_Bool success = new Dto_Bool();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    //fetching the existing record whose UserID == user.UserID from 
                    //the database
                    
                    var profileRecordFromDB = db.Profiles.Where(
                        c => c.profileID == profile.ProfileID).FirstOrDefault();


                    //changing the values
                    if (profileRecordFromDB != null)
                    {
                        if (profileRecordFromDB.profileID == 0)
                        {
                            success.success = false;
                            success.ErrorMessage = "Not Found .";
                            return success;
                        }
                        else
                        {
                            profileRecordFromDB.pictureID = (int)profile.PictureID;
                            profileRecordFromDB.AccountNumber = (int)profile.AccountNumber;
                            profileRecordFromDB.AvgRating = (double)profile.AvgRating;
                            profileRecordFromDB.Bio = profile.Bio;


                            //updating the values in database
                            db.SaveChanges();

                            success.success = true;
                        }
                    }
                    else
                    {
                        success.success = false;
                        success.ErrorMessage = "Not Found .";
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                success.success = false;
                success.ErrorMessage = ex.Message;
            }
            return success;
        }


        public Dto_Bool DeleteProfile(Dto_Profile profile)
        {
            
            Dto_Bool success = new Dto_Bool();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var profileRecordFromDB = db.Profiles.Where(
                        c => c.profileID == profile.ProfileID).FirstOrDefault();

                    if (profileRecordFromDB != null)
                    {
                        if (profileRecordFromDB.profileID == 0)
                        {
                            success.success = false;
                            success.ErrorMessage = "Not Found .";
                            return success;
                        }
                        else
                        {
                            db.Profiles.Remove(profileRecordFromDB);
                            db.SaveChanges();
                            success.success = true;
                        }
                    }
                    else
                    {
                        success.success = false;
                        success.ErrorMessage = "Not Found .";
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                success.success = false;
                success.ErrorMessage = ex.Message;
            }
            return success;
        }
        public List<Dto_Profile> GetAllProfiles()
        {
            List<Dto_Profile> profiles = new List<Dto_Profile>();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var list = db.Profiles;
                    foreach (var u in list)
                    {
                        var p = new Dto_Profile();
                        p.UserID = u.userID;
                        p.ProfileID = u.profileID;
                        p.PictureID = (int)u.pictureID;
                        p.AccountNumber = (int)u.AccountNumber;
                        p.AvgRating = (double)u.AvgRating;
                        p.Bio = u.Bio;

                        profiles.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                return profiles;//an empty list of Profiles
            }

            return profiles;//a populated list of profiles
        }
        #endregion accessTableProfile

        #region accessTablePicture

        public Dto_Picture GetPicture(Dto_User user)
        {

            //Dto_Profile profile = new Dto_Profile();
            Dto_Picture p = new Dto_Picture();
            p.ErrorMessage = "not found";
            p.Error = true;
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {

                    var profile = db.Profiles.Where(c => c.userID == user.UserID).
                    FirstOrDefault();

                    if (profile != null)
                    {
                        if (profile.profileID != 0)
                        {

                            var singleRecord = db.Pictures.Where(c => c.userID == user.UserID
                                    && c.pictureID == profile.pictureID).
                                    FirstOrDefault();

                            if (singleRecord != null)
                            {
                                if (singleRecord.pictureID != 0)
                                {
                                    p.PictureID = singleRecord.pictureID;
                                    p.UserID = singleRecord.userID;
                                    p.PropertyID = singleRecord.propertyID;
                                    p.PicturePath = singleRecord.picturePath;
                                    p.Error = false;
                                    p.ErrorMessage = "";
                                }
                            }
                        }
                    }
                            
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;
            }
  
            return p;
        }

        public Dto_Picture InsertPicture(Dto_Picture pictureGiven)
        {
            Dto_Picture p = new Dto_Picture();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var singleRecord = new DAL.Picture();

                    singleRecord.userID = pictureGiven.UserID;
                    singleRecord.pictureID = (int)pictureGiven.PictureID;
                    singleRecord.propertyID = pictureGiven.PropertyID;
                    singleRecord.picturePath = pictureGiven.PicturePath;

                    var newRecord = db.Pictures.Add(singleRecord);
                    db.SaveChanges();

                    if (newRecord != null)
                    {
                        if (newRecord.pictureID == 0)
                        {
                            p.ErrorMessage = "not found";
                            p.Error = true;
                            return p;
                        }
                        else
                        {
                            p.PictureID = newRecord.pictureID;
                            p.UserID = newRecord.userID;
                            p.PropertyID = newRecord.propertyID;
                            p.PicturePath = newRecord.picturePath;
                            p.Error = false;
                        }

                    }
                    else
                    {
                        p.Error = true;
                        p.ErrorMessage = "Insert into table Pictures was unsuccessful !!!";

                    }
                }
            }
            catch (Exception ex)
            {
                p.Error = true;
                p.ErrorMessage = ex.Message;
            }
            return p;
        }

        public Dto_Bool UpdatePicture(Dto_Picture pictureGiven)
        {
            Dto_Bool success = new Dto_Bool();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    //fetching the existing record whose UserID == user.UserID from 
                    //the database
                    var pictureRecordFromDB = db.Pictures.Where(
                        c => c.pictureID== pictureGiven.PictureID).FirstOrDefault();

                    //changing the values
                    if (pictureRecordFromDB != null)
                    {
                        if (pictureRecordFromDB.pictureID == 0)
                        {
                            success.success = false;
                            success.ErrorMessage = "not found. ";
                            return success;
                        }
                        else
                        {
                            pictureRecordFromDB.userID = pictureGiven.UserID;
                            pictureRecordFromDB.propertyID = pictureGiven.PropertyID;
                            pictureRecordFromDB.picturePath = pictureGiven.PicturePath;

                            //updating the values in database
                            db.SaveChanges();

                            success.success = true;
                        }
                    }
                    else
                    {
                        success.success = false;
                        success.ErrorMessage = "not found. ";
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                success.success = false;
                success.ErrorMessage = ex.Message;
            }
            return success;
        }


        public Dto_Bool DeletePicture(Dto_Picture pictureGiven)
        {          
            Dto_Bool success = new Dto_Bool();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var pictureRecordFromDB = db.Pictures.Where(
                        c => c.pictureID == pictureGiven.PictureID).FirstOrDefault();
                    if (pictureRecordFromDB != null)
                    {
                        if (pictureRecordFromDB.pictureID == 0)
                        {
                            success.success = false;
                            success.ErrorMessage = "not found. ";
                            return success;
                        }
                        else
                        {
                            db.Pictures.Remove(pictureRecordFromDB);
                            db.SaveChanges();
                            success.success = true;
                        }
                    }
                    else
                    {
                        success.success = false;
                        success.ErrorMessage = "not found. ";
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                success.success = false;
                success.ErrorMessage = ex.Message;
            }
            return success;
        }
        public List<Dto_Picture> GetAllPictures()
        {
            List<Dto_Picture> picturesList = new List<Dto_Picture>();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var list = db.Pictures;
                    foreach (var pic in list)
                    {
                        var p = new Dto_Picture();
                        p.PictureID = pic.pictureID;
                        p.UserID = pic.userID;
                        p.PropertyID = pic.propertyID;
                        p.PicturePath = pic.picturePath;

                        picturesList.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                return picturesList;//an empty list of Pictures
            }
            return picturesList;//a populated list of Pictures
        }
        #endregion accessTablePicture

        #region classmates
        public List<Dto_Property> GetPropertiesByUser(Dto_User user)
        {
            List<Dto_Property> properties = new List<Dto_Property>();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var propertiesFromSQL = db.Properties.Where(c => c.userID == user.UserID);
                    foreach (var o in propertiesFromSQL)
                    {
                        var a = db.Addresses.SingleOrDefault(c => c.AddressID
                                    == o.Address.AddressID);

                        // Get associated property from database
                        var p = new Dto_Property
                        {
                            UserID = o.userID,
                            PropertyID = o.PropertyID,

                            // Get associated address from database
                            Address = new Dto_Address()
                            {
                                AddressID = o.Address.AddressID,
                                AddressLine1 = a.Line1,
                                AddressLine2 = a.Line2,
                                City = a.city,
                                State = a.state,
                                ZipCode = a.zip.ToString()
                            },

                            // Instantiate an empty photo list
                            photos = new List<string>() { },

                            priceLight = o?.priceLight ?? 0,
                            priceMedium = o?.priceMedium ?? 0,
                            priceHeavy = o?.priceHeavy ?? 0,

                            size = Convert.ToInt32(o.size),
                            numBeds = Convert.ToInt32(o.numBedrooms),
                            numBaths = Convert.ToInt32(o.numBathrooms),
                            isVacant = o.isVacant == 1 ? true : false,
                            hasPets = o.hasPets == 1 ? true : false,
                            desc = o.description
                        };

                        // Loop to add pictures to the picture list
                        //var n = db.Pictures.Where(c => c.propertyID == o.PropertyID).ToList();
                        //if (n != null)
                        //{
                        //    for (int i = 0; i < n.Count; i++)
                        //    {
                        //        p.photos.Add(n.ElementAt(i).picturePath);
                        //    }
                        //}

                        properties.Add(p);
                    }
                }
                return properties;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public List<Dto_Listing> GetListings(GeoCoordinate location)
        {
            List<Dto_Listing> localListings = new List<Dto_Listing>();
            List<Dto_Listing> allListings = new List<Dto_Listing>();
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var list = db.Listings.Where(l => l.isLive != 0);
                    foreach (var listing in list)
                    {
                        var tempListing = new Dto_Listing();
                        tempListing.listingID = listing.listingID;
                        tempListing.propertyID = listing.propertyID;
                        tempListing.userID = listing.userID;
                        tempListing.listingStartTime = listing?.listingStartTime ?? new DateTime();
                        tempListing.listingExpiryTime = listing?.listingExpiryTime ?? new DateTime();
                        tempListing.cleaningLevelID = listing?.cleaningLevelID ?? 0;
                        tempListing.additionalInfo = listing.additionalInfo;
                        tempListing.isLive = listing.isLive == 1 ? true : false;
                        allListings.Add(tempListing);
                    }

                    foreach (var listing in allListings)
                    {
                        var property = db.Properties.Where(i => i.PropertyID == listing.propertyID).SingleOrDefault();
                        if (location.GetDistanceTo(new GeoCoordinate(property.Address?.latitude ?? 0, 
                            property.Address?.longitude ?? 0)) < 32186.9)
                        {
                            listing.location = new GeoCoordinate(property?.latitude ?? 0, property?.longitude ?? 0);
                            localListings.Add(listing);
                        }
                    }

                    return localListings;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Dto_Bid GetBid(Dto_Bid bid)
        {
            Dto_Bid b = new Dto_Bid();
            using (UMaidEntities db = new UMaidEntities())
            {
                var singleRecord = db.Bids.Where(c => c.bidID == bid.BidID).SingleOrDefault();

                if (singleRecord != null)
                {
                    b.BidID = singleRecord.bidID;
                    b.ListingID = singleRecord.listingID;
                    b.UserID = singleRecord.userID;
                    b.BidPrice = singleRecord.bidPrice;
                    b.StartTime = singleRecord.startTime;
                    b.BidExpires = singleRecord.bidExpires;
                    b.IsAccepted = singleRecord.isAccepted;
                }
                else
                {
                    b.ErrorMessage = "Not found";
                    b.Error = true;
                }
            }
            return b;
        }
        public List<Dto_Bid> GetBids()
        {
            List<Dto_Bid> bidList = new List<Dto_Bid>();

            using (UMaidEntities db = new UMaidEntities())
            {
                var bidObjects = db.Bids.ToList();

                foreach (var o in bidObjects)
                {
                    Dto_Bid bid = new Dto_Bid();

                    bid.BidID = o.bidID;
                    bid.ListingID = o.listingID;
                    bid.UserID = o.userID;
                    bid.BidPrice = o.bidPrice;
                    bid.StartTime = o.startTime;
                    bid.BidExpires = o.bidExpires;
                    bid.IsAccepted = o.isAccepted;

                    bidList.Add(bid);
                }
            }
            return bidList;
        }
        public List<Dto_Transaction> GetCustomerTransactions(Dto_User user)
        {
            List<Dto_Transaction> transactions;
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var listing = db.Listings.Where(b => b.userID == user.UserID).FirstOrDefault();
                    transactions = (List<Dto_Transaction>)db.Transactions.Where(t => t.listingID == listing.listingID);

                    return transactions;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Dto_Transaction> GetMaidTransactions(Dto_User user)
        {
            List<Dto_Transaction> transactions;
            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var bid = db.Bids.Where(b => b.userID == user.UserID).FirstOrDefault();

                    transactions = (List<Dto_Transaction>)db.Transactions.Where(t => t.bidID == bid.bidID);

                    return transactions;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Dto_Bool InsertProperty(Dto_Property property)
        {
            Dto_Bool isInserted = new Dto_Bool();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    // Save address to the database
                    var a = new Address
                    {
                        userID = property.UserID,
                        Line1 = property.Address?.AddressLine1,
                        Line2 = property.Address?.AddressLine2,
                        city = property.Address?.City,
                        state = property.Address?.State,
                        zip = string.IsNullOrWhiteSpace(property.Address.ZipCode) ? 0
                            : Convert.ToInt32(property.Address.ZipCode)
                    };

                    db.Addresses.Add(a);
                    db.SaveChanges();

                    // Save property to the database
                    var p = new Property
                    {
                        userID = property.UserID,
                        AddressID = a.AddressID,
                        size = property.size,

                        priceLight = property.priceLight,
                        priceMedium = property.priceMedium,
                        priceHeavy = property.priceHeavy,
                        numBedrooms = property.numBeds,
                        numBathrooms = property.numBaths,
                        description = property.desc,
                        isVacant = property.isVacant ? 1 : 0,
                        hasPets = property.hasPets ? 1 : 0
                    };
                    
                    db.Properties.Add(p);
                    db.SaveChanges();

                    // Add created PropertyID back to the address
                    var n = db.Addresses.Where(c => c.AddressID == p.AddressID).SingleOrDefault();
                    var m = db.Properties.Where(c => n.AddressID == c.AddressID).SingleOrDefault();
                    n.propertyID = m.PropertyID;

                    // Save property pictures to the database
                    //for (int i = 0; i < property.photos.Count; i++)
                    //{
                    //    db.Pictures.Add(new Picture
                    //    {
                    //        userID = property.UserID,
                    //        propertyID = property.PropertyID,
                    //        picturePath = property.photos.ElementAt(i)
                    //    });
                    //}

                    db.SaveChanges();

                    isInserted.success = true;
                }
            }
            catch (Exception ex)
            {
                isInserted.ErrorMessage = ex.Message;
            }

            return isInserted;
        }
        public Dto_Bool UpdateProperty(Dto_Property property)
        {
            Dto_Bool isUpdated = new Dto_Bool();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    var p = db.Properties.Where(c => c.userID == property.UserID
                                               && c.PropertyID == property.PropertyID).SingleOrDefault();
                    var a = db.Addresses.Where(c => c.AddressID == property.Address.AddressID).SingleOrDefault();      
                    //var i = db.Pictures.Where(c => c.propertyID == p.PropertyID).SingleOrDefault();

                    a.Line1 = property.Address?.AddressLine1;
                    a.Line2 = property.Address?.AddressLine2;
                    a.city = property.Address?.City;
                    a.state = property.Address?.State;
                    a.zip = string.IsNullOrWhiteSpace(property.Address.ZipCode)? 
                        0 : Convert.ToInt32(property.Address.ZipCode);

                    p.size = property.size;
                    p.numBedrooms = property.numBeds;
                    p.numBathrooms = property.numBaths;
                    p.description = property.desc;
                    p.isVacant = property.isVacant ? 1 : 0;
                    p.hasPets = property.hasPets ? 1 : 0;

                    //if (i == null) // Create a new pictureID
                    //{
                    //    var c = new Picture()
                    //    {
                    //        userID = property.UserID,
                    //        propertyID = property.PropertyID,
                    //        picturePath = property.photos.ElementAtOrDefault(0)
                    //    };

                    //    db.Pictures.Add(c);
                    //    db.SaveChanges();
                    //}
                    //else // Modify URL of an already existing picture
                    //{
                    //    i.userID = property.UserID;
                    //    i.propertyID = property.PropertyID;
                    //    i.picturePath = property.photos.ElementAtOrDefault(0);
                    //}

                    db.SaveChanges();
                }

                isUpdated.success = true;
            }
            catch (Exception ex)
            {
                isUpdated.ErrorMessage = ex.Message;
            }

            return isUpdated;
        }
        public Dto_Bool DeleteProperty(Dto_Property property)
        {
            Dto_Bool isDeleted = new Dto_Bool();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {
                    // Remove pictures from Pictures table
                    //db.Pictures.Remove(db.Pictures.Where(c => c.propertyID
                    //                        == property.PropertyID).SingleOrDefault());
                    //db.SaveChanges();

                    // Remove property from Properties table
                    db.Properties.Remove(db.Properties.Where(c => c.PropertyID
                                            == property.PropertyID).SingleOrDefault());
                    db.SaveChanges();

                    // Remove address from Addresses table
                    db.Addresses.Remove(db.Addresses.Where(c => c.propertyID
                                            == property.PropertyID).SingleOrDefault());
                    db.SaveChanges();  
                }

                isDeleted.success = true;
            }
            catch (Exception ex)
            {
                isDeleted.ErrorMessage = ex.Message;
            }

            return isDeleted;
        }
        public Dto_Bid InsertBid(Dto_Bid bid)
        {
            Dto_Bid insertedRec = new Dto_Bid();
            DAL.Bid bidRec = new DAL.Bid();

            try
            {
                using (UMaidEntities db = new UMaidEntities())
                {

                    bidRec.bidID = bid.BidID;
                    bidRec.userID = bid.UserID;
                    bidRec.listingID = bid.ListingID;
                    bidRec.bidPrice = bid.BidPrice;
                    bidRec.startTime = bid.StartTime;
                    bid.BidExpires = bid.BidExpires;
                    bid.IsValid = bid.IsValid;

                    var newRec = db.Bids.Add(bidRec);
                    db.SaveChanges();

                    if (newRec != null)
                    {
                        insertedRec.BidID = newRec.bidID;
                        insertedRec.ListingID = newRec.listingID;
                        insertedRec.UserID = newRec.userID;
                        insertedRec.StartTime = newRec.startTime;
                        insertedRec.BidExpires = newRec.bidExpires;
                        insertedRec.BidPrice = newRec.bidPrice;
                    }
                }
            }
            catch (Exception ex)
            {
                insertedRec.ErrorMessage = ex.Message;
                insertedRec.Error = false;
            }
            return insertedRec;
        }
        public Dto_Bool UpdateBid(Dto_Bid bid)
        {
            Dto_Bool updateResult = new Dto_Bool();


            Dto_Bid recToBeUpdated = new Dto_Bid();

            using (UMaidEntities db = new UMaidEntities())
            {
                try
                {
                    var updatedRec = db.Bids.Find(bid.BidID);

                    updatedRec.userID = bid.UserID;
                    updatedRec.listingID = bid.ListingID;
                    updatedRec.bidPrice = bid.BidPrice;
                    updatedRec.startTime = bid.StartTime;
                    updatedRec.bidExpires = bid.BidExpires;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    updateResult.ErrorMessage = ex.Message;
                    updateResult.Error = false;
                }
            }
            updateResult.success = true;
            return updateResult;
        }
        public Dto_Bool DeleteBid(Dto_Bid bid)
        {
            Dto_Bool deletionResult = new Dto_Bool();

            Dto_Bid deletionRec = new Dto_Bid();

            using (UMaidEntities db = new UMaidEntities())
            {
                try
                {
                    var recordToBeDeleted = db.Bids.Find(bid.BidID);
                    db.Bids.Remove(recordToBeDeleted);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    deletionResult.success = false;
                    deletionResult.ErrorMessage = ex.Message;
                    deletionResult.Error = false;
                }
            }

            deletionResult.success = true;
            return deletionResult;
        }
        #endregion classmates
    }

}
