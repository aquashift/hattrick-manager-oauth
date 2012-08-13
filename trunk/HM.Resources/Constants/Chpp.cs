using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources.Constants {
    public static class Chpp {
        public const string ConsumerKey = "dpf43f3p2l4k3l03";
        public const string ConsumerSecret = "kd94hf93k423kf44";
        public const string UserAgent = "Hattrick Manager v0.01 (Gavry)";
        public const string SignatureMethod = "HMAC-SHA1";
        public const string OAuthCallback = "oob";
        public const string RequestTokenURL = "https://chpp.hattrick.org/oauth/request_token.ashx";
        public const string AuthorizeURL = "https://chpp.hattrick.org/oauth/authorize.aspx";
        public const string AuthenticateURL = "https://chpp.hattrick.org/oauth/authenticate.aspx";
        public const string AccessTokenURL = "https://chpp.hattrick.org/oauth/access_token.ashx";
        public const string CheckTokenURL = "https://chpp.hattrick.org/oauth/check_token.ashx";
        public const string InvalidateTokenURL = "https://chpp.hattrick.org/oauth/invalidate_token.ashx";
        public const string ResourcesURL = "http://chpp.hattrick.org/chppxml.ashx";
        public const string HMDateFormat = "yyyy-MM-dd";
    }
}