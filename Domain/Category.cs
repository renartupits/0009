using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class Category: DomainEntityMetadata
    {
        [MaxLength(128)] public string Name { get; set; } = default!;

    }
}