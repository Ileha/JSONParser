namespace JSONParserLibrary.Reactors
{
	public class ColonFabric : AbstractReactorFabric {
		public override char Name {
			get {
				return ':';
			}
		}

		public override AbstractReactor CreateInstanse(int index) {
			return new Colon(index);
		}
	}

    public class Colon : AbstractReactor {
        public Colon(int index) : base(':', index) {}

        public override void Work(ReactorData data) {}
    }
}
