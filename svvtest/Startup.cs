using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace svvtest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var svvOpenIdConnectAuthenticationOptions = new OpenIdConnectAuthenticationOptions
            {
                //   AuthenticationType = "svv",
                //   Caption = "SVV Test",
                Authority = "https://www.test.vegvesen.no:443/openam/oauth2/employees",
                ClientId = "ComAround",
                ClientSecret = "",
                Scope = "openid svvprofile",
                ResponseType = "token id_token",
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthenticationFailed = AuthenticationFailed,
                    //   RedirectToIdentityProvider = RedirectToIdentityProvider,
                    //  SecurityTokenValidated = context => TransformClaims(context, SvvClaimsTransformation)
                },
                RedirectUri = "http://localhost:64870",
                //   PostLogoutRedirectUri = "http://localhost:64870/customers",
                SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                //       AuthenticationMode = AuthenticationMode.Passive
            };

            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute(
                name: "AllCustomers",
                routeTemplate: "customers",
                defaults: new { controller = "Customers", action = "Get" }
            );
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(svvOpenIdConnectAuthenticationOptions);
            app.UseWebApi(httpConfiguration);
        }

        private static Task AuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> authenticationFailedNotification)
        {
            //       serilogAdapter.Exception(authenticationFailedNotification.Exception);
            return Task.FromResult(0);
        }
    }
}