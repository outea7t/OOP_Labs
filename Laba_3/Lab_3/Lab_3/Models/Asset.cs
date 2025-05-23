using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public string? Ticker { get; set; }

        public string? Name { get; set; }

        public List<PortfolioAsset>? PortfolioAssets { get; set; }
    }
}
