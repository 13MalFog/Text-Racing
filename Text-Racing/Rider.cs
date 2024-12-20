

class Rider
{
    public string RiderName { get; set; }
    public int SpeedAdd { get; set; }
    public int AccelerationAdd { get; set; }
    public Rider(string riderName, int speedAdd, int accelerationAdd)
    {
        this.RiderName = riderName;
        this.SpeedAdd = speedAdd;
        AccelerationAdd = accelerationAdd;
    }
}