using System.ComponentModel.DataAnnotations;

public class Customer 
{
    public int CustomerId { get; set; }
    [Required]
    [UniqueCompanyName(ErrorMessage = "Company name must be unique.")]
    public string CompanyName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Region { get; set; }
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Phone { get; set; }
    public string Fax { get; set; }
}
public class UniqueCompanyNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbContext = (DataContext)validationContext.GetService(typeof(DataContext));
        var customer = (Customer)validationContext.ObjectInstance;

        if (dbContext.Customers.Any(c => c.CompanyName == value.ToString() && c.CustomerId != customer.CustomerId))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}

