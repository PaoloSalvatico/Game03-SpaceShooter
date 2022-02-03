using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Classe astratta utilizzata per creare i controller delle navicelle,
    /// sia del giocatore, sia dei nemici
    /// </summary>
    public abstract class AbstractShipController : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField]
        protected ShipDataScriptableObject _data;

        protected virtual void Start()
        {
            // Inizializzazione
        }

        // Espone le statistiche della navicella
        public ShipDataScriptableObject Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }

}
