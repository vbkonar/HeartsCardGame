//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hearts.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Moves = new HashSet<Move>();
            this.Users = new HashSet<User>();
        }
    
        public int GameId { get; set; }
        public int Status { get; set; }
        public int Player1 { get; set; }
        public Nullable<int> Player2 { get; set; }
        public Nullable<int> Player3 { get; set; }
        public Nullable<int> Player4 { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int Player3Score { get; set; }
        public int Player4Score { get; set; }
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual User User3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Move> Moves { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

    }

    public enum GameStatus
    {
        Waiting,
        Started,
        Ended,
        Aborted
    };
}

