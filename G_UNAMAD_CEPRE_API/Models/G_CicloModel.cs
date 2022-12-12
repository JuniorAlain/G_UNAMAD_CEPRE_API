namespace G_UNAMAD_CEPRE_API.Models
{
    public class G_CicloModel
    {
        public string IdCiclo { get; set; }
        public string NCiclo { set; get; }
        public string Periodo { set; get; }
        public DateTime FInicio { set; get; }
        public DateTime FFin { set; get; }
        public int EProgreso { set; get; }
        public int Activo { set; get; }
        public DateTime FRegistroM { set; get; }
        public string CVersion { set; get; }
    }
}