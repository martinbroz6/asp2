using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace InsuranceCorp.Model;
public class Contract
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(10)]
    public string PlateNumber { get; set; }
    public DateTime Signed { get; set; }
    public CarBrand CarBrand { get; set; }
    
    [MaxLength(20)]
    public string HexColor { get; set; }


    public int PersonId { get; set; }

    [JsonIgnore]
    public Person Person { get; set; }

    public override string ToString() => $"{Id} - {Name} - {PlateNumber} - {CarBrand} - {Signed.ToString("yyyy-MM-dd")}";


}

public enum CarBrand
{
    Skoda,
    Volkswagen,
    MercedesBenz,
    BMW,
    Citroen,
    Peugeot,
    Fiat,
    Ford,
    Toyota,
    Renault,
}
