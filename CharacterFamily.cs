namespace characterDesignAPI
{
    public class CharacterFamily
    {
        public Guid FamilyId { get; set; }
        public Guid CharacterId { get; set; }
        public string Mother { get; set; }
        public string RelationshipWithMother { get; set; }
        public string Father { get; set; }
        public string RelationshipWithFather { get; set; }
        public string Siblings { get; set; }
        public string RelationshipWithSiblings { get; set; }
        public string Spouse { get; set; }
        public string RelationshipWithSpouse { get; set; }
        public string Children { get; set; }
        public string OtherFamily { get; set; }

    }
}
