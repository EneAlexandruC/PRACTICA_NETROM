namespace ShowTime.Entities
{
    public class BandFestival
    {
        public int FestivalId { get; set; }
        public Festival? Festival { get; set; }
        public int BandId { get; set; }
        public Band? Band { get; set; }
        public int OrderNo { get; set; }
    }
}
