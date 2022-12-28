namespace G_UNAMAD_CEPRE_API.Models
{
    public class G_CicloModel
    {
        public string IdCiclo { get; set; }
        public string NCiclo { get; set; }
        public string Periodo { get; set; }
        public DateTime FInicio { get; set; }
        public DateTime FFin { get; set; }
        public int EProgreso { get; set; }
        public int Activo { get; set; }
        public DateTime FRegistroM { get; set; }
        public string CVersion { get; set; }
    }
}