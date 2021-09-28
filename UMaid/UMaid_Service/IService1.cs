using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Device.Location;
using DAL;
using Model;

namespace UMaid_Service
{
    [ServiceContract]
    public interface IService1
    {
        #region AccessTableUserTypes
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_UserType GetUserType(Dto_User user);

        #endregion AccessTableUserTypes
        #region accessTableUsers
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_User GetUser(Dto_User user);


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_User GetUserByUserID(Dto_User user);


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_User InsertUser(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool UpdateUser(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool DeleteUser(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_User> GetAllUsers();
        #endregion accessTableUsers


        #region accessTableProfiles
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Profile GetProfile(Dto_User user);
                     


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Profile InsertProfile(Dto_Profile profile);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool UpdateProfile(Dto_Profile profile);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool DeleteProfile(Dto_Profile profile);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Profile> GetAllProfiles();

        #endregion accessTableProfiles

        #region accessTablePictures
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Picture GetPicture(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Picture InsertPicture(Dto_Picture pictureGiven);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool UpdatePicture(Dto_Picture pictureGiven);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool DeletePicture(Dto_Picture pictureGiven);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Picture> GetAllPictures();

        #endregion accessTablePictures


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Property> GetPropertiesByUser(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Listing> GetListings(GeoCoordinate location);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Transaction> GetCustomerTransactions(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Transaction> GetMaidTransactions(Dto_User user);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool InsertProperty(Dto_Property p);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool UpdateProperty(Dto_Property p);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool DeleteProperty(Dto_Property p);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bid GetBid(Dto_Bid bid);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        List<Dto_Bid> GetBids();
        
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bid InsertBid(Dto_Bid bid);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool UpdateBid(Dto_Bid bid);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [return: MessageParameter(Name = "Data")]
        [OperationContract]
        Dto_Bool DeleteBid(Dto_Bid bid);
    }
}
