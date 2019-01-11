namespace CapaEntidades
{
    public class AreaEmpleado
    {
        int ID_Area { get; set; }
        string Nombre_Area { get; set; }

        public AreaEmpleado() { }

        public AreaEmpleado(int ID_Area, string Nombre_Area)
        {
            this.ID_Area = ID_Area;
            this.Nombre_Area = Nombre_Area;
        }
    }
}