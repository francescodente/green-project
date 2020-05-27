namespace GreenProject.Backend.Entities
{
    public enum UnitName
    {
        Kilogram,
        Piece
    }

    public static class UnitNameExtensions
    {
        public static string GetPrintableName(this UnitName unitName)
        {
            return unitName switch
            {
                UnitName.Kilogram => "kg",
                UnitName.Piece => "pz",
                _ => null
            };
        }
    }
}
