

class Kart
{
    public string KartName {  get; set; }
    public int KartSpeed {  get; set; }
    public int KartAcceleration { get; set; }
    public Kart(string kartName, int kartSpeed, int kartAcceleration)
    {
        KartName = kartName;
        KartSpeed = kartSpeed;
        KartAcceleration = kartAcceleration;
    }
}