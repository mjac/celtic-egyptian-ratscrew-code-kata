namespace CelticEgyptianRatscrewKata.Tests
{
    class DummySnapValidator : ISnapValidator
    {
        private readonly bool _hasSnap;

        public DummySnapValidator(bool hasSnap)
        {
            _hasSnap = hasSnap;
        }

        public bool Validate(Stack stack)
        {
            return _hasSnap;
        }
    }
}