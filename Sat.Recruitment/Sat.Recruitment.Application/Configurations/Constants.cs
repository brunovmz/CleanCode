
namespace Sat.Recruitment.Application.Configurations
{
    public static class Constants
    {
        public const string PropertyNameRequired = "The {PropertyName} is required";
        public const string RequestFailed = "Request Failed";
        public const string RequestCreatedSuccess = "Request Created Successfully";
        public const string UserDuplicated = "User is duplicated";

        public const string UserPost = "Create User";
        public const string UserGet = "Get Users";

        #region User Types

        public const string Normal = "Normal";
        public const string SuperUser = "SuperUser";
        public const string Premium = "Premium";

        public static readonly decimal GifNormal12 = Convert.ToDecimal(0.12);
        public static readonly decimal GifNormal8 = Convert.ToDecimal(0.8);
        public static readonly decimal GifSuperUser20 = Convert.ToDecimal(0.20);

        #endregion
    }
}
