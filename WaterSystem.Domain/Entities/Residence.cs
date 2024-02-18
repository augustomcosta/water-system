using System.ComponentModel.DataAnnotations;
using WaterSystem.Domain.Entities.Base;
using WaterSystem.Domain.Validation;

namespace WaterSystem.Domain.Entities;

public class Residence : BaseEntity
{
    [Required] 
    public string Block { get; private set; } = "";
    
    [Required]
    public int Number { get; private set; }
    
    [Required]
    public decimal Hydrometer { get; private set; }
    
    
    public Residence(Guid id, string block, int number, decimal hydrometer) : base(id)
    {
        ValidateResidence(block,number,hydrometer);
    }

    public void UpdateResidence(Residence residence)
    {
        residence.Number = Number;
        residence.Block = Block;
        residence.Hydrometer = Hydrometer;
    }

    private void ValidateResidence(string block,int number,decimal hydrometer)
    {
        ValidateBlock(block);
        ValidateNumber(number);
        ValidateHydrometer(hydrometer);
    }

    private void ValidateBlock(string block)
    {
        DomainValidationException.When(string.IsNullOrEmpty(block), "Block is required.");
        DomainValidationException.When(string.IsNullOrWhiteSpace(block), "Block is required.");
        DomainValidationException.When(block.Length > 3,"Invalid block. Block should have a maximum of 3 characters");
        Block = block;
    }

    private void ValidateNumber(int number)
    {
        DomainValidationException.When(number < 1,"Invalid Number. Number should be greater than zero.");
        DomainValidationException.When(number > 999,"Invalid Number. Number should be 3 characters long at maximum.");
        Number = number;
    }

    private void ValidateHydrometer(decimal hydrometer)
    {
        DomainValidationException.When(decimal.IsNegative(hydrometer),"Invalid hydrometer reading. Reading should be positive.");
        Hydrometer = hydrometer;
    }
}