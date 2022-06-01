namespace AnimalHotelSystem.Model.ValueObjects
{
    public class CageDimensions
    {
        public double Length { get; }
        public double Width { get; }
        public double Height { get; set; }

        public double Volume => Length * Width * Length;

        public CageDimensions(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}
