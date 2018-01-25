namespace LightingVisualization.Model
{
    /// <summary>
    /// Powierzchnia (metaliczna, mieszana, matowa) 
    /// </summary>
    public class Surface
    {
        /// <summary>
        /// Współczynnik odbicia światła kierunkowego
        /// </summary>
        public double Ks { get; set; }
        /// <summary>
        /// Współczynnik odbicia światła rozproszonego
        /// </summary>
        public double Kd { get; set; }
        /// <summary>
        /// Współczynnik gładkości powierzchni
        /// Im większy współczynnik, tym lepsze właściwości odbicia kierunkowego
        /// Dla N = 100 zbliżamy się do właściwości lustrzanych
        /// </summary>
        public double N { get; set; }
    }
}
