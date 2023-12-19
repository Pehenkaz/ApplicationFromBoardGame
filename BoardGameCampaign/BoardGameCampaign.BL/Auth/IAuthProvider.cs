using BoardGameCampaign.BL.Auth.Entities;

namespace BoardGameCampaign.BL.Auth;

public interface IAuthProvider
{
    Task<TokensResponse> AuthorizePlayer(string email, string password);
    //register - do by yourself
}