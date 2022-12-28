namespace G_UNAMAD_CEPRE_API.Models
{
    public class G_CicloModelDTO
    {
        public string idCiclo { get; set; }
        public string nCiclo { get; set; }
        public string periodo { get; set; }
        public DateTime fInicio { get; set; }
        public DateTime fFin { get; set; }
        public int eProgreso { get; set; }
        public int activo { get; set; }
    }
}
