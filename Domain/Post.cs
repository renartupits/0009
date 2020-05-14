using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;

namespace Domain
{
    public class Post: DomainEntityMetadata
    {
        [MaxLength(4096)]
        public string Body { get; set; } = default!;

        public string AuthorId { get; set; }
        public Author? Author { get; set; } = default!;

        [ForeignKey(nameof(PersonWhoHasWrittenIt))]
        public string MyCustomFk { get; set; }
        public Author? PersonWhoHasWrittenIt { get; set; }

        [ForeignKey(nameof(CoAuthor))]
        public string SecondFk { get; set; }
        public Author? CoAuthor { get; set; }
    }
}