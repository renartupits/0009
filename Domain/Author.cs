using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Author: DomainEntityMetadata
    {
        [MaxLength(64)] [MinLength(1)] public string FirstName { get; set; } = default!;
        
        [MaxLength(64)] [MinLength(1)] public string LastName { get; set; }  = default!;

        [MaxLength(64)] public string AppUserId { get; set; } = default!;
        public AppUser? AppUser { get; set; }

        
        [InverseProperty(nameof(Post.PersonWhoHasWrittenIt))]
        public ICollection<Post>? AuthoredPosts { get; set; }
        
        
        [InverseProperty(nameof(Post.CoAuthor))]
        public ICollection<Post>? CoAuthoredPosts { get; set; }

        public ICollection<Post>? Posts { get; set; }

        [NotMapped] public string FirstLastName => FirstName + " " + LastName;
    }
}