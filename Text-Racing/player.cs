

class Player
{
    public Rider PlayerRider { get; set; }
    public Kart PlayerKart { get; set; }

    public Player(Rider playerRider, Kart playerKart, string playerName)
    {
        PlayerRider = playerRider;
        PlayerKart = playerKart;
    }
}