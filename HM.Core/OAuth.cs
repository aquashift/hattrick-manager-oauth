using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMEntities = HM.Entities.HattrickManager;
using HM.Resources.Constants;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace HM.Core {
    public class OAuthInterface {
        private IToken requestToken;

        public OAuthInterface(IToken token) {
            this.requestToken = token;
        }

        public OAuthInterface() {
        }

        public String AccessProtectedResource(HMEntities.UserProfiles.User currentUser, String parameters) {
            String URL = Chpp.ResourcesURL + "?" + parameters;
            OAuthSession oAuthSession = GetOAuthSession(Chpp.ConsumerKey, Chpp.ConsumerSecret);

            oAuthSession.AccessToken = new TokenBase() { ConsumerKey = Chpp.ConsumerKey, Token = currentUser.accessToken, TokenSecret = currentUser.accessTokenSecret };

            IConsumerRequest request = oAuthSession.Request().Get().ForUrl(URL);

            return (request.ToString());
        }

        public String GetRequestTokenURL() {
            String AuthorizationURL = String.Empty;
            OAuthSession oauthSession = GetOAuthSession(Chpp.ConsumerKey, Chpp.ConsumerSecret);

            try {
                requestToken = oauthSession.GetRequestToken("GET");
                AuthorizationURL = oauthSession.GetUserAuthorizationUrlForToken(requestToken);
            } catch {
                AuthorizationURL = String.Empty;
            }

            return (AuthorizationURL);
        }

        public void ExchangeRequestTokenForAccessToken(String verifier, out HMEntities.UserProfiles.User currentUser) {
            currentUser = new HMEntities.UserProfiles.User();

            OAuthSession oauthSession = GetOAuthSession(Chpp.ConsumerKey, Chpp.ConsumerSecret);
            IToken accessToken = oauthSession.ExchangeRequestTokenForAccessToken(requestToken, verifier);

            currentUser.accessToken = accessToken.Token;
            currentUser.accessTokenSecret = accessToken.TokenSecret;
        }

        private OAuthSession GetOAuthSession(String key, String secret) {
            OAuthConsumerContext consumerContext = new OAuthConsumerContext();

            consumerContext.ConsumerKey = key;
            consumerContext.ConsumerSecret = secret;
            consumerContext.SignatureMethod = SignatureMethod.HmacSha1;

            return (new OAuthSession(consumerContext, Chpp.RequestTokenURL, Chpp.AuthorizeURL, Chpp.AccessTokenURL));
        }


        #region IDisposable Members

        public void Dispose() {
            if (requestToken != null) {
                requestToken = null;
            }
        }

        #endregion
    }
}