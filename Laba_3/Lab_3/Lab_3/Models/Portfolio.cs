using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    public class Portfolio
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public List<PortfolioAsset>? PortfolioAssets { get; set; }
    }
}
