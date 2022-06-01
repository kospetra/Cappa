namespace AnimalHotelSystem.Model.ValueObjects
{
    public class RoomDimensions
    {
        public double Length { get; }
        public double Width { get; }

        public double AreaSize => Length * Width;

        public RoomDimensions(double length, double width)
        {
            Length = length;
            Width = width;
        }
    }
}
