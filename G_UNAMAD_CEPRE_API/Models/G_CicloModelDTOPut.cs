﻿namespace G_UNAMAD_CEPRE_API.Models
{
    public class G_CicloModelDTOPut
    {
        public string nCiclo { set; get; }
        public string periodo { set; get; }
        public DateTime fInicio { set; get; }
        public DateTime fFin { set; get; }
        public int eProgreso { set; get; }
        public int activo { set; get; }
    }
}
