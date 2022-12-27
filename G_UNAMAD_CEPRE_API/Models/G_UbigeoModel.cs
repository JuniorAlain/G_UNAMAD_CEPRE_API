namespace G_UNAMAD_CEPRE_API.Models
{
    public class G_UbigeoModel
    {
        public string IdUbigeo { get; set; }
        public string CDepartamento { get; set; }
        public string NDepartamento { get; set; }
        public string CProvincia { get; set; }
        public string NProvincia { get; set; }
        public string CDistrito { get; set; }
        public string NDistrito { get; set; }
        public int Activo { get; set; }
        public DateTime FRegistroM { get; set; }
        public string CVersion { get; set; }
    }
}
