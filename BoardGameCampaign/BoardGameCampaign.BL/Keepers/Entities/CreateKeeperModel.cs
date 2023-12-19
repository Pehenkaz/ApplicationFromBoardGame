namespace BoardGameCampaign.BL.Keepers.Entities;

public class CreateKeeperModel
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string? Patronymic { get; set; }
    public int Age { get; set; }
    public string Nickname { get; set; }
}