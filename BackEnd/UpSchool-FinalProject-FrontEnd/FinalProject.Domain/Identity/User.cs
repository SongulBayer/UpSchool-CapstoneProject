using FinalProject.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Identity

{
    //string id tipini verir
    public class User : IdentityUser<string>, ICreatedByEntity, IEntityBase<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTimeOffset? CreatedOn { get ; set ; }
        public string? CreatedByUserId { get ; set ; }
    }
}
