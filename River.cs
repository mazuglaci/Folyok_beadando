using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folyok_beadando {
    ///Használati terv:
    ///     Alapból egy folyik tömbje van megadott számú folyóval
    ///     Mindig összekötésnél így könnyen lehet a megfelelő indexűeket kezelni
    ///     Később pedig már elegendő a folyók eltárolt adatain menni végig (EndRiver, ContainedRivers), a tömb csak a feltöltéshez kell.
 
    class River {
        /// <summary>
        /// Folyó azonosítója
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// A folyó amibe folyik
        /// </summary>
        public River EndRiver { get; private set; }

        /// <summary>
        /// A folyók amikbe belefolynak
        /// </summary>
        public List<River> ContainedRivers { get; private set; }

        /// <summary>
        /// Logikai érték, hogy bele folyik-e másik folyóba
        /// </summary>
        public bool HasEndRiver { get => EndRiver != null; }

        public River(int id) {
            ID = id;
            EndRiver = null;
            ContainedRivers = new List<River>();
        }

        ///<summary>
        ///visszaállítás hogy nem másik folyóba folyik
        ///</summary>
        public void RemoveEnd() {
            if (HasEndRiver) {
                RemoveFlow(this);
            }
        }

        ///<summary>
        ///ez a folyó befolyik a targetRiver-be
        ///</summary>
        public void SetEnd(River targetRiver) {
            if(HasEndRiver) {
                RemoveFlow(this);
            }
            CreateFlow(this, targetRiver);
        }

        ///<summary>
        ///paraméterben megadott river befolyik ebbe a folyóba
        ///</summary>
        public void SetContains(River river) {
            if (river.HasEndRiver) {
                RemoveFlow(river);
            }
            CreateFlow(river, this);
        }

        private static void CreateFlow(River river, River targetRiver) {
            river.EndRiver = targetRiver;
            targetRiver.ContainedRivers.Add(river);
        }

        private static void RemoveFlow(River river) {
            river.EndRiver.ContainedRivers.Remove(river);
            river.EndRiver = null;
        }

        ///<summary>
        ///ToString a teszteléshez
        ///</summary>
        public override string ToString() {
            return $"{ID} - End: {(HasEndRiver ? EndRiver.ID.ToString() : "N/A")} Contains: {(ContainedRivers.Count == 0 ? "N/A" : string.Join(", ", ContainedRivers.Select(r => r.ID)))}";
        }
    }
}
