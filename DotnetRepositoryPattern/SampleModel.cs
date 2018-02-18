namespace DotnetRepositoryPattern {
    public class SampleModel : IModel<long> {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }

        public override bool Equals(object obj) {
            return obj is SampleModel model && Equals(model);
        }

        private bool Equals(SampleModel other) {
            return Id == other.Id && string.Equals(Name, other.Name) && string.Equals(Address, other.Address);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}