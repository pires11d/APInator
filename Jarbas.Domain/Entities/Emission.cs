using Jarbas.Domain.Interfaces;
using System;

namespace Jarbas.Domain.Entities
{
    public class Emission : IEntity
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string Travel { get; set; }
    }
}
