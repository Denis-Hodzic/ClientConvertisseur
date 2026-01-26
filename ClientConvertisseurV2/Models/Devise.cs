using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Models
{
    public class Devise
    {
        public Devise(int id, string? nomDevice, double taux)
        {
            this.Id = id;
            this.NomDevise = nomDevice;
            this.Taux = taux;
        }

        public Devise()
        {

        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string? nomDevise;
        [Required]
        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }

        private double taux;

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   this.id == devise.id &&
                   this.NomDevise == devise.NomDevise &&
                   this.Taux == devise.Taux;
        }
    }
}
