//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatMessRyb.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupChat
    {
        public int Id_GroupChat { get; set; }
        public Nullable<int> Id_Employee { get; set; }
        public Nullable<int> Id_Chatroom { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Chatroom Chatroom { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
