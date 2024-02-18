using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WaterSystem.Domain.Validation;


namespace WaterSystem.Domain.Entities.Base;

public abstract class BaseEntity
{

    public BaseEntity() {}

    public BaseEntity(Guid id)
    {
        ValidateId(id);
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }


    private void ValidateId(Guid id)
    {
        DomainValidationException.When(string.IsNullOrEmpty(id.ToString()),"Id is required");
        DomainValidationException.When(string.IsNullOrWhiteSpace(id.ToString()),"Id is required");
        Id = id;
    }
}