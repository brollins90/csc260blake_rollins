//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialSiteV4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Favorites
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Profile Profile { get; set; }
    }
}