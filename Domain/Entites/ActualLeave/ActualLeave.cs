﻿using Domain.Entites.BaseEntity;
using Domain.Enumerable;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ActualLeave : Entity<Guid>
    {
        public Guid LeaveTypeId { get; set; }
        public Guid ReasonCodeId { get; set; }
        public string? Description { get; set; }
        public double Remaining { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public FeedBack? FeedBacks { get; set; } = FeedBack.Pending;
        [ForeignKey(nameof(LeaveTypeId))] public LeaveType? LeaveType { get; set; }
        [ForeignKey(nameof(ReasonCodeId))] public ReasonCode? ReasonCode { get; set; }
        public ICollection<MemberActualLeave>? MemberActualLeave { get; set; }
        public ICollection<ActualLeaveRecord>? ActualLeaveRecord { get; set; }
    }

}
