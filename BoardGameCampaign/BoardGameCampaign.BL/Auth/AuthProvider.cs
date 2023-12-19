using Duende.IdentityServer.Models;
using BoardGameCampaign.BL.Auth.Entities;
using BoardGameCampaign.DataAccess.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;

namespace BoardGameCampaign.BL.Auth;

public class AuthProvider : IAuthProvider
{
    private readonly SignInManager<PlayerEntity> _signInManager;
    private readonly UserManager<PlayerEntity> _playerManager;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _identityServerUri;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public AuthProvider(SignInManager<PlayerEntity> signInManager, UserManager<PlayerEntity> playerManager,
        IHttpClientFactory httpClientFactory,
        string identityServerUri,
        string clientId,
        string clientSecret)
    {
        _signInManager = signInManager;
        _playerManager = playerManager;
        _identityServerUri = identityServerUri;
        _httpClientFactory = httpClientFactory;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    public async Task<TokensResponse> AuthorizePlayer(string email, string password)
    {
        var player = await _playerManager.FindByEmailAsync(email); //IRepository<PlayerEntity> get player by email
        if (player is null)
        {
            throw new Exception(); //PlayerNotFoundException, BusinessLogicException(Code.PlayerNotFound);
        }

        var verificationPasswordResult = await _signInManager.CheckPasswordSignInAsync(player, password, false);
        if (!verificationPasswordResult.Succeeded)
        {
            throw new Exception(); //AuthorizationException, BusinessLogicException(Code.PasswordOrLoginIsIncorrect);
        }

        var client = _httpClientFactory.CreateClient();
        var discoveryDoc = await client.GetDiscoveryDocumentAsync(_identityServerUri); 
        if (discoveryDoc.IsError)
        {
            throw new Exception();
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
        {
            Address = discoveryDoc.TokenEndpoint,
            GrantType = GrantType.ResourceOwnerPassword,
            ClientId = _clientId,
            ClientSecret = _clientSecret,
            UserName = player.FirstName,
            Password = password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new Exception();
        }

        return new TokensResponse()
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken
        };
    }

    public async Task RegisterUser(string email, string password)
    {
        PlayerEntity userEntity = new PlayerEntity()
        {
            Login = email, //REQUIRED !!!!!!
            FirstName = email
        };

        var createUserResult = await _playerManager.CreateAsync(userEntity, password);
    }
}