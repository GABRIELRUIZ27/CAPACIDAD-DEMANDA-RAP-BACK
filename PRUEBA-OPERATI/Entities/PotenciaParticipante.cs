namespace PRUEBA_OPERATI.Entities
{
    public class PotenciaParticipante
    {
        public int Id { get; set; }  
        public string ZonaPotencia { get; set; }
        public string Participante { get; set; }
        public string Subcuenta { get; set; }
        public double CapacidadDemandadaMW { get; set; }
        public double RequisitoAnualMWAnio { get; set; }
        public double ValorRequisitoEficienteMWAnio { get; set; }
    }
}
